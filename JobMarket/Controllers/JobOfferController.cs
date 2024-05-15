using JobMarket.Models.JobOfferViewModels;
using JobMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JobMarket.Services.Abstract;
using JobMarket.Models.JobTypeVİewModels;
using JobMarket.Models.JobCategoryViewModels;


namespace JobMarket.Controllers
{
    public class JobOfferController(
        IJobOfferService jobOfferService,
        IJobCategoryService jobCategoryService,
        IJobTypeService jobTypeService,
        IAuthService authService,
        IMapper mapper) : Controller
    {
        private readonly IJobOfferService _jobOfferService = jobOfferService;
        private readonly IJobCategoryService _jobCategoryService = jobCategoryService;
        private readonly IJobTypeService _jobTypeService = jobTypeService;
        private readonly IAuthService _authService = authService;
        private readonly IMapper _mapper = mapper;

        public object AuthorId { get; private set; }
        public IEnumerable<JobCategory> JobCategories { get; private set; }
        public IEnumerable<JobType> JobTypes { get; private set; }

        [AllowAnonymous]
        public IActionResult Error(int? statusCode)
        {
            var vm = new ErrorViewModel
            {
                Response = statusCode?.ToString() ?? "-",
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(vm);
        }

        // GET: JobOffer
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var jobOffers = await _jobOfferService.GetAllOffers();
            var vms = _mapper.Map<IList<JobOfferViewModel>>(jobOffers);
            ViewData["JobOfferCount"] = vms.Count;

            if (!await _authService.IsSignedIn(HttpContext.User))
            {
                return View(vms);
            }

            var userId = (_authService.GetSignedUser(User)).Id;
            foreach (var offer in vms)
            {
                offer.CanEdit = await _jobOfferService.CanUserEditOffer(userId, offer.JobOfferId);
            }

            return View(vms);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string phrase)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return RedirectToAction(nameof(Index));
            }

            var matchingOffers = await _jobOfferService.GetOffersContainingPhrase(phrase);
            var vms = _mapper.Map<IList<JobOfferViewModel>>(matchingOffers);
            ViewData["JobOfferCount"] = vms.Count;
            ViewData["phrase"] = phrase;

            if (!await _authService.IsSignedIn(HttpContext.User))
            {
                return View("Index", vms);
            }

            var userId = (_authService.GetSignedUser(User)).Id;
            foreach (var offer in vms)
            {
                offer.CanEdit = await _jobOfferService.CanUserEditOffer(userId, offer.JobOfferId);
            }
            return View("Index", vms);
        }

        // GET: JobOffer/Popular
        [AllowAnonymous]
        public async Task<IActionResult> Popular()
        {
            var popularJobOffers = await _jobOfferService.GetMostPopularOffers();
            var vms = _mapper.Map<IEnumerable<PopularJobOfferViewModel>>(popularJobOffers);
            return View(vms);
        }

        // GET: JobOffer/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var jobOffer = await _jobOfferService.GetOfferById(id);
            if (jobOffer == null)
            {
                return View("NotFound");
            }

            await _jobOfferService.IncreaseOfferViews(jobOffer);

            var vm = _mapper.Map<DetailsJobOfferViewModel>(jobOffer);
            if (!await _authService.IsSignedIn(HttpContext.User))
            {
                return View(vm);
            }

            vm.CanEdit = await _jobOfferService.CanUserEditOffer((_authService.GetSignedUser(User)).Id, vm.JobOfferId);
            return View(vm);
        }

        // GET: JobOffer/Create
       // public async Task<IActionResult> Create()
     //   {
       //     {
        //        AuthorId = (await _authService.GetSignedUser(User)).Id;
           //     JobCategories = await _jobCategoryService.GetAllCategories();
         //       JobTypes = await _jobTypeService.GetAllTypes();
         //   };

           // var viewModel = CreateJobOfferViewModel
          //  return View(viewModel);
       // }

        // POST: JobOffer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateJobOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.JobCategories = await _jobCategoryService.GetAllCategories();
                model.JobTypes = await _jobTypeService.GetAllTypes();
                return View(model);
            }

            var jobOffer = _mapper.Map<JobOffer>(model);
            var result = await _jobOfferService.Add(jobOffer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }

        // GET: JobOffer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }
            var offer = await _jobOfferService.GetOfferById(id);
            if (offer == null)
            {
                return View("NotFound");
            }

           // var user = await _authService.GetSignedUser(User);
           // if (!await _jobOfferService.CanUserEditOffer(user.Id, offer.JobOfferId))
           // {
             //   return View("AccessDenied");
           // }

            var vm = _mapper.Map<EditJobOfferViewModel>(offer);
            vm.JobCategories = await _jobCategoryService.GetAllCategories();
            vm.JobTypes = await _jobTypeService.GetAllTypes();
            return View(vm);
        }

        // POST: JobOffer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditJobOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.JobCategories = await _jobCategoryService.GetAllCategories();
                model.JobTypes = await _jobTypeService.GetAllTypes();
                return View(model);
            }

            var offer = _mapper.Map<JobOffer>(model);
            var result = await _jobOfferService.Edit(offer);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }

        // GET: JobOffer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var jobOffer = await _jobOfferService.GetOfferById(id);
            if (jobOffer == null)
            {
                return View("NotFound");
            }

            //var user = await _authService.GetSignedUser(User);
           // if (await _jobOfferService.CanUserEditOffer(user.Id, jobOffer.JobOfferId))
            {
                return View(jobOffer);
            }

          //  return View("AccessDenied");
        }

        // POST: JobOffer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var result = await _jobOfferService.Delete(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("NotFound");
        }
    }

    internal interface IMapper
    {
        T Map<T>(EditJobOfferViewModel model);
        T Map<T>(CreateJobOfferViewModel model);
        object Map<T>(JobOffer offer);
        string? Map<T>(IEnumerable<JobOffer> popularJobOffers);
        string? Map<T>(JobType jobType);
        string? Map<T>(IEnumerable<JobType> result);
        T Map<T>(EditJobTypeViewModel model);
        T Map<T>(DeleteJobTypeViewModel model);
        string? Map<T>(JobCategory category);
        string? Map<T>(IEnumerable<JobCategory> jobCategories);
        T Map<T>(CreateJobCategoryViewModel model);
        T Map<T>(EditJobCategoryViewModel model);
        T Map<T>(DeleteJobCategoryViewModel model);
    }
}
