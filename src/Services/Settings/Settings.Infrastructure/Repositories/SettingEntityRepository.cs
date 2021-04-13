using Settings.Domain.AggregatesModel.SettingEntityAggregate;
using Settings.Domain.SeedWork;
using System;

namespace Settings.Infrastructure.Repositories
{
    public class SettingEntityRepository : ISettingEntityRepository
    {
        private readonly SettingsContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public SettingEntityRepository(SettingsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}