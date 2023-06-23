using System;
using Dapper;
using Backend_Test.Context;
using Backend_Test.Models;

namespace Backend_Test.Repositories
{
    public class OrganizationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrganizationRepository(DatabaseContext context)
        {
            _databaseContext = context;
        }

        //Question 2i
        public async Task<IEnumerable<Organization>> GetAll()
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT OrgID, Name, BusinessRegistrationNo, Address, Postcode, ContactNo,
                        LastUpdatedDatetime FROM public.organization;";
            var result = await connection.QueryAsync<Organization>(sql);

            return result;
        }

        //Question 2ii
        public async Task<Organization> GetById(int OrgID)
        {
            using var connection = _databaseContext.CreateConnection();

            var sql = @"SELECT OrgID, Name, BusinessRegistrationNo, Address, Postcode, ContactNo,
                        LastUpdatedDatetime FROM public.organization
                        WHERE Id = @OrgID;";
            var result = await connection.QueryFirstOrDefaultAsync<Organization>(sql, new { Id = OrgID });

            return result;
        }

        //Question 2iii
        public async Task<Organization> InsertOrg(Organization organization)
        {
            using var connection = _databaseContext.CreateConnection();

            // assign dummy value
            //organization.Name = "HelloWorld";
            //organization.BusinessRegistrationNo = "Abc123456";
            //organization.Address = "No1, Jalan Segambut";
            //organization.Postcode = 51200;
            //organization.ContactNo = "012-3456789";

            var sql = @"INSERT INTO public.organization (Name, BusinessRegistrationNo, Address, Postcode, ContactNo) VALUES
                       (@Name, @BusinessRegistrationNo, @Address, @Postcode, @ContactNo);";
            var result = await connection.QueryFirstOrDefaultAsync<Organization>(sql, new { Name = organization.Name, BusinessRegistrationNo = organization.BusinessRegistrationNo, Address = organization.Address, Postcode = organization.Postcode, ContactNo = organization.ContactNo });
            return result;
        }

        //Question 2iv
        public async Task<Organization> UpdateOrg(Organization organization)
        {
            using var connection = _databaseContext.CreateConnection();

            // assign dummy value
            //organization.ContactNo = "987-6543210";

            var sql = @"UPDATE public.organization SET ContactNo = @ContactNo WHERE Name = 'HelloWorld';";

            var result = await connection.QueryFirstOrDefaultAsync<Organization>(sql, new { ContactNo = organization.ContactNo });
            return result;
        }

        //Question 2v
        public async Task<Organization> DeleteOrg(Organization organization)
        {
            using var connection = _databaseContext.CreateConnection();

            // assign dummy value
            //organization.Name = "HelloWorld";

            var sql = @"DELETE FROM public.organization WHERE Name = @Name;";

            var result = await connection.QueryFirstOrDefaultAsync<Organization>(sql, new { Name = organization.Name });
            return result;
        }

    }
}
