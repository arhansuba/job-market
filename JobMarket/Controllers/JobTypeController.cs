using JobMarket.Models.JobTypeViewModels;
using JobMarket.Models.JobTypeVİewModels;
using JobMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JobMarket.Services.Abstract;
using AutoMapper;
using JobMarket.Helpers;

namespace JobMarket.Controllers
{
    public class JobTypeController(IJobTypeService jobTypeService, IMapper mapper) : Controller
    {
        [Authorize(Roles = RoleHelper.Administrator)]
       
        
            private readonly IJobTypeService _jobTypeService = jobTypeService;
            private readonly IMapper _mapper = mapper;

        // GET: JobType
        public async Task<IActionResult> Index()
            {
                var result = await _jobTypeService.GetAllTypes();
                var vm = _mapper.Map<IEnumerable<JobTypeViewModel>>(result);
                return View(vm);
            }

            // GET: JobType/Details/5
            public async Task<IActionResult> Details(string id)
            {
                if (id == null)
                {
                    return View("NotFound");
                }

                var jobType = await _jobTypeService.GetTypeById(id);
                if (jobType == null)
                {
                    return View("NotFound");
                }

                var vm = _mapper.Map<DetailsJobTypeViewModel>(jobType);
                return View(vm);
            }

            // GET: JobType/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: JobType/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(CreateJobTypeViewModel model, Mapper mapper)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var result = await _jobTypeService.Add(item: mapper.Map<JobType>(model));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("NotFound");
            }

            // GET: JobType/Edit/5
            public async Task<IActionResult> Edit(string id)
            {
                if (id == null)
                {
                    return View("NotFound");
                }

                var jobType = await _jobTypeService.GetTypeById(id);
                if (jobType == null)
                {
                    return View("NotFound");
                }

                var vm = _mapper.Map<EditJobTypeViewModel>(jobType);
                return View(vm);
            }

            // POST: JobType/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(EditJobTypeViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var type = _mapper.Map<JobType>(model);
                var result = await _jobTypeService.Edit(type);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("NotFound");
            }

            // GET: JobType/Delete/5
            public async Task<IActionResult> Delete(string id)
            {
                if (id == null)
                {
                    return View("NotFound");
                }

                var jobType = await _jobTypeService.GetTypeById(id);
                if (jobType == null)
                {
                    return View("NotFound");
                }

                var vm = _mapper.Map<DeleteJobTypeViewModel>(jobType);
                return View(vm);
            }

            // POST: JobType/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(DeleteJobTypeViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var jobType = _mapper.Map<JobType>(model);
                var result = await _jobTypeService.Delete(jobType);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("NotFound");
            }
        }
    }

