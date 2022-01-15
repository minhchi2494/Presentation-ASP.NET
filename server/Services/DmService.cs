using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using Dm1.Data;

namespace Dm1
{
    public partial class DmService
    {
        DmContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly DmContext context;
        private readonly NavigationManager navigationManager;

        public DmService(DmContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportAttributesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dm/attributes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dm/attributes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAttributesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dm/attributes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dm/attributes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAttributesRead(ref IQueryable<Models.Dm.Attribute> items);

        public async Task<IQueryable<Models.Dm.Attribute>> GetAttributes(Query query = null)
        {
            var items = Context.Attributes.AsQueryable();

            items = items.Include(i => i.Setting);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAttributesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAttributeCreated(Models.Dm.Attribute item);
        partial void OnAfterAttributeCreated(Models.Dm.Attribute item);

        public async Task<Models.Dm.Attribute> CreateAttribute(Models.Dm.Attribute _attribute)
        {
            OnAttributeCreated(_attribute);

            var existingItem = Context.Attributes
                              .Where(i => i.Code == _attribute.Code)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Attributes.Add(_attribute);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(_attribute).State = EntityState.Detached;
                _attribute.Setting = null;
                throw;
            }

            OnAfterAttributeCreated(_attribute);

            return _attribute;
        }
        public async Task ExportSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dm/settings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dm/settings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dm/settings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dm/settings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSettingsRead(ref IQueryable<Models.Dm.Setting> items);

        public async Task<IQueryable<Models.Dm.Setting>> GetSettings(Query query = null)
        {
            var items = Context.Settings.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSettingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSettingCreated(Models.Dm.Setting item);
        partial void OnAfterSettingCreated(Models.Dm.Setting item);

        public async Task<Models.Dm.Setting> CreateSetting(Models.Dm.Setting setting)
        {
            OnSettingCreated(setting);

            var existingItem = Context.Settings
                              .Where(i => i.AttributeID == setting.AttributeID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Settings.Add(setting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(setting).State = EntityState.Detached;
                throw;
            }

            OnAfterSettingCreated(setting);

            return setting;
        }

        partial void OnAttributeDeleted(Models.Dm.Attribute item);
        partial void OnAfterAttributeDeleted(Models.Dm.Attribute item);

        public async Task<Models.Dm.Attribute> DeleteAttribute(string _code)
        {
            var itemToDelete = Context.Attributes
                              .Where(i => i.Code == _code)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAttributeDeleted(itemToDelete);

            Context.Attributes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAttributeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAttributeGet(Models.Dm.Attribute item);

        public async Task<Models.Dm.Attribute> GetAttributeByCode(string _code)
        {
            var items = Context.Attributes
                              .AsNoTracking()
                              .Where(i => i.Code == _code);

            items = items.Include(i => i.Setting);

            var itemToReturn = items.FirstOrDefault();

            OnAttributeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Dm.Attribute> CancelAttributeChanges(Models.Dm.Attribute item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAttributeUpdated(Models.Dm.Attribute item);
        partial void OnAfterAttributeUpdated(Models.Dm.Attribute item);

        public async Task<Models.Dm.Attribute> UpdateAttribute(string _code, Models.Dm.Attribute _attribute)
        {
            OnAttributeUpdated(_attribute);

            var itemToUpdate = Context.Attributes
                              .Where(i => i.Code == _code)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(_attribute);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterAttributeUpdated(_attribute);

            return _attribute;
        }

        partial void OnSettingDeleted(Models.Dm.Setting item);
        partial void OnAfterSettingDeleted(Models.Dm.Setting item);

        public async Task<Models.Dm.Setting> DeleteSetting(string attributeId)
        {
            var itemToDelete = Context.Settings
                              .Where(i => i.AttributeID == attributeId)
                              .Include(i => i.Attributes)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSettingDeleted(itemToDelete);

            Context.Settings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSettingDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSettingGet(Models.Dm.Setting item);

        public async Task<Models.Dm.Setting> GetSettingByAttributeId(string attributeId)
        {
            var items = Context.Settings
                              .AsNoTracking()
                              .Where(i => i.AttributeID == attributeId);

            var itemToReturn = items.FirstOrDefault();

            OnSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Dm.Setting> CancelSettingChanges(Models.Dm.Setting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSettingUpdated(Models.Dm.Setting item);
        partial void OnAfterSettingUpdated(Models.Dm.Setting item);

        public async Task<Models.Dm.Setting> UpdateSetting(string attributeId, Models.Dm.Setting setting)
        {
            OnSettingUpdated(setting);

            var itemToUpdate = Context.Settings
                              .Where(i => i.AttributeID == attributeId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(setting);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSettingUpdated(setting);

            return setting;
        }
    }
}
