﻿namespace JobMarket.Data
{
    

        public interface IMigrationManager
        {
            /// <summary>
            /// Apply any pending migrations.
            /// </summary>
            /// <returns>apply task</returns>
            Task Apply();
        }
    }




