using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace WellsFargo_Dapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
      
        private readonly IMapper _mapper;
        public PerformanceController(IPerformanceDbManager dbManager, IMapper mapper)
        {
            _dbmanager = dbManager;
            _mapper = mapper;
        }
        //Api to return most recent 10 Accounts added into database.
        [HttpGet]
        [Route("PgPeriodList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgPeriodViewModel>>> GetPgPeriod()
        {
            Log.Information($"PerformanceController.GetPgPeriod method started");
            var accountsList = _mapper.Map<PgPeriodViewModel[]>(await _dbmanager.GetPgPeriod());
            Log.Information($"PerformanceController.GetPgPeriod method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("QueryOwnerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QueryOwnerViewModel>>> GetQueryOwners()
        {
            Log.Information($"PerformanceController.GetQueryOwners method started");
            var queryOwners = _mapper.Map<QueryOwnerViewModel[]>(await _dbmanager.GetQueryOwners());
            Log.Information($"PerformanceController.GetQueryOwners method completed");
            return Ok(queryOwners);
        }
        [HttpGet]
        [Route("GetAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgAccountViewModel>>> GetAllAccounts()
        {
            Log.Information($"PerformanceController.GetAllAccounts method started");
            var accountsList = _mapper.Map<PgAccountViewModel[]>(await _dbmanager.GetAllAccounts());
            Log.Information($"PerformanceController.GetAllAccounts method completed");
            return Ok(accountsList);
        }
        [HttpPut]
        [Route("UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> UpdateBook(List<UpdateBookViewModel> bookViewModel)
        {
            Log.Information($"PerformanceController.UpdateBook method started");
            var bookModel = _mapper.Map<List<UpdateBookViewModel>, List<UpdateBook>>(bookViewModel);
            var updateResult = _mapper.Map<PgAccountViewModel[]>(await _dbmanager.UpdateBook(bookModel));
            Log.Information($"PerformanceController.UpdateBook method completed");
            return Ok(updateResult);
        }
        [HttpGet]
        [Route("GetAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgAccountViewModel>>> GetAccounts()
        {
            Log.Information($"PerformanceController.GetAccounts method started");
            var accountsList = _mapper.Map<PgAccountViewModel[]>(await _dbmanager.GetAccounts());
            Log.Information($"PerformanceController.GetAccounts method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("SaveAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> SaveAccount(PgAccountViewModel pgAccountViewModel)
        {
            Log.Information($"PerformanceController.SaveAccount method started");
            var pgAccount = _mapper.Map<PgAccountViewModel, PgAccount>(pgAccountViewModel);
            var saveResult = await _dbmanager.SaveAccount(pgAccount);
            Log.Information($"PerformanceController.SaveAccount method completed");
            return Ok(saveResult);
        }
        [HttpGet]
        [Route("AccountsListByPeriod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgCompanyViewModel>>> GetAccountsListByPeriods(int pgPeriod, int owner)
        {
            Log.Information($"PerformanceController.GetAccountsListByPeriods method started");
            var accounts = _mapper.Map<PgCompanyViewModel[]>(await _dbmanager.GetAccountsListByPeriods(pgPeriod, owner));
            Log.Information($"PerformanceController.GetAccountsListByPeriods method completed");
            return Ok(accounts);
        }
        [HttpPut]
        [Route("UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> UpdateAccount(int primaryKey, int accountId)
        {
            Log.Information($"PerformanceController.UpdateAccount method started");
            var updateResult = _mapper.Map<PgPeriodViewModel[]>(await _dbmanager.UpdateAccount(primaryKey, accountId));
            Log.Information($"PerformanceController.UpdateAccount method completed");
            return Ok(updateResult);
        }
        [HttpDelete]
        [Route("DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteAccount(int accountId)
        {
            Log.Information($"PerformanceController.DeleteAccount method started");
            var deleteResult = _mapper.Map<bool>(await _dbmanager.DeleteAccount(accountId));
            Log.Information($"PerformanceController.DeleteAccount method completed");
            return Ok(deleteResult);
        }
        [HttpGet]
        [Route("CheckAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> CheckAccount(int accountId)
        {
            Log.Information($"PerformanceController.CheckAccount method started");
            var accountsList = _mapper.Map<int>(await _dbmanager.CheckAccount(accountId));
            Log.Information($"PerformanceController.CheckAccount method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("GuaranteeList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgGuaranteeViewModel>>> GetGuaranteeList()
        {
            Log.Information($"PerformanceController.GetGuaranteeList method started");
            var guaranteeList = _mapper.Map<PgGuaranteeViewModel[]>(await _dbmanager.GetGuaranteeList());
            Log.Information($"PerformanceController.GetGuaranteeList method completed");
            return Ok(guaranteeList);
        }
        [HttpGet]
        [Route("CompanyByAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgCompanyViewModel>>> GetCompanyByAccount(int account)
        {
            Log.Information($"PerformanceController.GetCompanyByAccount method started");
            var accounts = _mapper.Map<PgCompanyViewModel[]>(await _dbmanager.GetCompanyByAccount(account));
            Log.Information($"PerformanceController.GetCompanyByAccount method completed");
            return Ok(accounts);
        }
        [HttpGet]
        [Route("ResultByAccountAndOwner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QueryResultByAccountAndOwnerViewModel>>> GetQueryResultByAccountAndOwner(int account, int owner, int pgPeriod)
        {
            Log.Information($"PerformanceController.GetQueryResultByAccountAndOwner method started");
            var list = _mapper.Map<QueryResultByAccountAndOwnerViewModel[]>(await _dbmanager.GetQueryResultByAccountAndOwner(account, owner, pgPeriod));
            Log.Information($"PerformanceController.GetQueryResultByAccountAndOwner method completed");
            return Ok(list);
        }
        [HttpPut]
        [Route("UpdateResult")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> UpdateResult(List<UpdateResultViewModel> resultViewModel)
        {
            Log.Information($"PerformanceController.UpdateResult method started");
            var resultModel = _mapper.Map<List<UpdateResultViewModel>, List<UpdateResult>>(resultViewModel);
            var updateResult = _mapper.Map<bool>(await _dbmanager.UpdateResult(resultModel));
            Log.Information($"PerformanceController.UpdateResult method completed");
            return Ok(updateResult);
        }
        [HttpGet]
        [Route("ReportResultByGuaranteeByPgPeriod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ReportResultByGuaranteeViewModel>>> GetReportResultByGuaranteeByPgPeriod(int pgPeriod)
        {
            Log.Information($"PerformanceController.GetReportResultByGuaranteeByPgPeriod method started");
            var results = _mapper.Map<ReportResultByGuaranteeViewModel[]>(await _dbmanager.GetReportResultByGuaranteeByPgPeriod(pgPeriod));
            Log.Information($"PerformanceController.GetReportResultByGuaranteeByPgPeriod method completed");
            return Ok(results);
        }
        [HttpGet]
        [Route("MetricsListByAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QueryMetricViewModel>>> GetMetricsListByAccount(int account)
        {
            Log.Information($"PerformanceController.GetMetricsListByAccount method started");
            var metrics = _mapper.Map<QueryMetricViewModel[]>(await _dbmanager.GetMetricsListByAccount(account));
            Log.Information($"PerformanceController.GetMetricsListByAccount method completed");
            return Ok(metrics);
        }
        [HttpGet]
        [Route("QueryReportingPeriodList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QueryReportingPeriodViewModel>>> GetQueryReportingPeriod()
        {
            Log.Information($"PerformanceController.GetQueryReportingPeriod method started");
            var accountsList = _mapper.Map<QueryReportingPeriodViewModel[]>(await _dbmanager.GetQueryReportingPeriod());
            Log.Information($"PerformanceController.GetQueryReportingPeriod method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("ReportResultByGuaranteePivot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ReportResultByGuaranteePivotViewModel>>> GetReportResultByGuaranteePivot(string group, int pgPeriod, int decimals)
        {
            Log.Information($"PerformanceController.GetReportResultByGuaranteePivot method started");
            var accountsList = _mapper.Map<ReportResultByGuaranteePivotViewModel[]>(await _dbmanager.GetReportResultByGuaranteePivot(group, pgPeriod, decimals));
            Log.Information($"PerformanceController.GetReportResultByGuaranteePivot method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("ReportResultByAccountPivot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ReportResultByAccountPivotViewModel>>> GetReportResultByAccountPivot(int account, int pgPeriod, int decimals)
        {
            Log.Information($"PerformanceController.GetReportResultByAccountPivot method started");
            var accountsList = _mapper.Map<ReportResultByAccountPivotViewModel[]>(await _dbmanager.GetReportResultByAccountPivot(account, pgPeriod, decimals));
            Log.Information($"PerformanceController.GetReportResultByAccountPivot method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("GetMeasurements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QueryMetricViewModel>>> GetMeasurements()
        {
            Log.Information($"PerformanceController.GetMeasurements method started");
            var accountsList = _mapper.Map<QueryMetricViewModel[]>(await _dbmanager.GetMeasurements());
            Log.Information($"PerformanceController.GetMeasurements method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("GetMetricsCountLinkedToAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgAccountViewModel>>> GetMetricsCountLinkedToAccount(int accountId)
        {
            Log.Information($"PerformanceController.GetMetricsCountLinkedToAccount method started");
            var accountsList = _mapper.Map<PgAccountViewModel[]>(await _dbmanager.GetMetricsCountLinkedToAccount(accountId));
            Log.Information($"PerformanceController.GetMetricsCountLinkedToAccount method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("GetResultsCountLinkedToAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgAccountViewModel>>> GetResultsCountLinkedToAccount(int accountId)
        {
            Log.Information($"PerformanceController.GetPgPeriod method started");
            var accountsList = _mapper.Map<PgAccountViewModel[]>(await _dbmanager.GetResultsCountLinkedToAccount(accountId));
            Log.Information($"PerformanceController.GetPgPeriod method completed");
            return Ok(accountsList);
        }
        [HttpPost]
        [Route("InsertMetricDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ResponseResultViewModel>> InsertMetric(PgMetricsViewModel metricsViewModel)
        {
            Log.Information($"PerformanceController.InsertMetric method started");
            var metrics = _mapper.Map<PgMetricsViewModel, PgMetrics>(metricsViewModel);
            var saveResult = _mapper.Map<bool>(await _dbmanager.InsertMetric(metrics));
            Log.Information($"PerformanceController.InsertMetric method completed");
            return Ok(saveResult);
        }
        [HttpPut]
        [Route("UpdateMetricDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ResponseResultViewModel>>> UpdateMetric(PgMetricsViewModel metricsViewModel)
        {
            Log.Information($"PerformanceController.UpdateMetrics method started");
            var metrics = _mapper.Map<PgMetricsViewModel, PgMetrics>(metricsViewModel);
            var saveResult = _mapper.Map<ResponseResultViewModel>(await _dbmanager.UpdateMetric(metrics));
            Log.Information($"PerformanceController.UpdateMetrics method completed");
            return Ok(saveResult);
        }
        [HttpDelete]
        [Route("DeleteMetric")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteMetric(int metric)
        {
            Log.Information($"PerformanceController.DeleteMetric method started");
            var saveResult = _mapper.Map<bool>(await _dbmanager.DeleteMetric(metric));
            Log.Information($"PerformanceController.DeleteMetric method completed");
            return Ok(saveResult);
        }
        [HttpGet]
        [Route("MetricDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PgMetricsViewModel>> GetMetricDetails(int metricId)
        {
            Log.Information($"PerformanceController.GetMetricDetails method started");
            var metricDetails = _mapper.Map<PgMetricsViewModel>(await _dbmanager.GetMetricDetails(metricId));
            Log.Information($"PerformanceController.GetMetricDetails method completed");
            return Ok(metricDetails);
        }
        [HttpGet]
        [Route("BookByPgPeriodList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<QueryBookByPgPeriodViewModel>>> GetBookByPgPeriod(int pgPeriod, int owner)
        {
            Log.Information($"PerformanceController.GetBookByPgPeriod method started");
            var accounts = _mapper.Map<QueryBookByPgPeriodViewModel[]>(await _dbmanager.GetBookByPgPeriod(pgPeriod, owner));
            Log.Information($"PerformanceController.GetBookByPgPeriod method completed");
            return Ok(accounts);
        }
        [HttpPost]
        [Route("GetOwnerIdbyEmailAddress")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<PgPeriodViewModel>>> GetOwnerIdbyEmailAddress(TableOwnerViewModel objTableOwnerViewModel)
        {
            Log.Information($"PerformanceController.GetOwnerIdbyEmailAddress method started");
            var accountsList = _mapper.Map<PgPeriodViewModel[]>(await _dbmanager.GetOwnerIdByEmailAddress(objTableOwnerViewModel));
            Log.Information($"PerformanceController.GetOwnerIdbyEmailAddress method completed");
            return Ok(accountsList);
        }
        [HttpGet]
        [Route("ReportResultByAccountByPgPeriod")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ReportResultByAccountViewModel>>> GetReportResultByAccountByPgPeriod(int pgPeriod)
        {
            Log.Information($"PerformanceController.GetReportResultByAccountByPgPeriod method started");
            var accounts = _mapper.Map<ReportResultByAccountViewModel[]>(await _dbmanager.GetReportResultByAccountByPgPeriod(pgPeriod));
            Log.Information($"PerformanceController.GetReportResultByAccountByPgPeriod method completed");
            return Ok(accounts);
        }
    }
}
