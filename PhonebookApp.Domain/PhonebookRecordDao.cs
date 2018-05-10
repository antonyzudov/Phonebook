using Domain.Abstract;
using System.Threading.Tasks;
using PhonebookApp.Models;
using Dapper;
using System.Data;
using System.Linq;
using System;

namespace PhonebookApp.Domain
{
    public class PhonebookRecordDao : BaseDao, IPhonebookRecordDao
    {
        public async Task<int> SaveAsync(PhonebookRecord model)
        {
            var isNew = model.Id == 0;

            return await WithConnection(async c =>
            {
                model.Id = await c.QueryFirstAsync<int>(
                    isNew ? SQL.InsertPerson : SQL.UpdatePerson,
                    new
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Surname = model.Surname,
                        Patronymic = model.Patronymic
                    }).ConfigureAwait(false);

                if (!isNew)
                {
                    await c.ExecuteAsync(
                        SQL.DeletePhoneNumbersByPersonId, 
                        new { PersonId = model.Id }).ConfigureAwait(false);
                }

                await c.ExecuteAsync(
                    SQL.InsertPhoneNumbers, 
                    model.PhoneNumbers.Select(x => new
                    {
                        PersonId = model.Id,
                        PhoneNumber = x
                    }).ToList()).ConfigureAwait(false);
                
                return model.Id;
            });
        }

        public async Task<PhonebookRecord> GetAsync(int id)
        {
            return await WithConnection(async c =>
            {
                var model = await c.QueryFirstAsync<PhonebookRecord>(
                    SQL.SelectPersonById,
                    new { Id = id }).ConfigureAwait(false);

                model.PhoneNumbers = (await c.QueryAsync<string>(
                    SQL.SelectPhoneNumbersByPersonId,
                    new { PersonId = id }).ConfigureAwait(false)).ToList();

                return model;
            });
        }
    }
}
