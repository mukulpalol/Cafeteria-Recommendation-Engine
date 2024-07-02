﻿using CafeteriaRecommendationSystem.DAL.Models;
using CafeteriaRecommendationSystem.DAL.RepositoriesContract;

namespace CafeteriaRecommendationSystem.DAL.Repositories
{
    internal class DiscardedMenuItemFeedbackRepository : Repository<DiscardedMenuItemFeedback>, IDiscardedMenuItemFeedbackRepository
    {
        public DiscardedMenuItemFeedbackRepository(CafeDbContext context) : base(context) { }
    }
}
