using SmartAccount.Core.Data;
using SmartAccount.Core.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace SmartAccount.Business.Services
{
    public class SettingService
    {
        private readonly SmartAccountDbContext _context;

        public SettingService()
        {
            _context = new SmartAccountDbContext();
        }

        public List<Setting> GetAllSettings()
        {
            return _context.Settings.ToList();
        }

        public string GetSetting(string key, string defaultValue = "")
        {
            var setting = _context.Settings.FirstOrDefault(s => s.Key == key);
            return setting?.Value ?? defaultValue;
        }

        public void SetSetting(string key, string value, string? description = null)
        {
            var setting = _context.Settings.FirstOrDefault(s => s.Key == key);
            if (setting == null)
            {
                setting = new Setting { Key = key, Value = value, Description = description };
                _context.Settings.Add(setting);
            }
            else
            {
                setting.Value = value;
                if (description != null) setting.Description = description;
                _context.Settings.Update(setting);
            }
            _context.SaveChanges();
        }
    }
}
