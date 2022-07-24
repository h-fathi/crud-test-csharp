using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Mc2.CrudTest.Shared.Data;
using MediatR;

namespace Mc2.CrudTest.Application.Features.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetCustomerByIdQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT " +
                               "[Customer].[Id], " +
                               "[Customer].[Lastname], " +
                               "[Customer].[Firstname], " +
                               "[Customer].[Email], " +
                               "[Customer].[DateOfBirth], " +
                               "[Customer].[PhoneNumber], " +
                               "[Customer].[BankAccountNumber] " +
                               "FROM [dbo].[Customers] AS [Customer] " +
                               "WHERE [Customer].[Id] = @CustomerId ";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            return connection.QuerySingleAsync<CustomerResponse>(sql, new
            {
                request.CustomerId
            });
        }
    }
}