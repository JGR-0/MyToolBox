using CalculosPlusvalias.Infrastructure;
using CalculosPlusvalias.Services;
using CalculosPlusvalias.UI.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculosPlusvalias.UI.MVC.Controllers
{
    public class GainsController : Controller
    {
        private readonly ILogger<GainsController> _logger;

        public GainsController(ILogger<GainsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GainsRequest(GainsRequestViewModel viewModel)
        {
            var transactions = await GetTransactionsFromFile(viewModel).ConfigureAwait(false);
            var responseViewModel = new GainsSummaryViewModel(transactions);
            return View("GainsSummary", responseViewModel);
        }

        private static async Task<IEnumerable<Transaction>> GetTransactionsFromFile(GainsRequestViewModel viewModel)
        {
            var rawTransactions = await viewModel.File.ReadLinesAsListAsync().ConfigureAwait(false);
            if (viewModel.WithHeaders)
            {
                rawTransactions.RemoveAt(0);
            }
            TransactionColumnsConfig.ConfigureTransactionColumnsConfig(
                viewModel.Splitter
                , viewModel.DateFormat
                , viewModel.ColumnsConfiguration.DateColNumber
                , viewModel.ColumnsConfiguration.TimeColNumber
                , viewModel.ColumnsConfiguration.ProductNameColNumber
                , viewModel.ColumnsConfiguration.ISINColNumber
                , viewModel.ColumnsConfiguration.ItemsNumberColNumber
                , viewModel.ColumnsConfiguration.LocalUnitPriceColNumber
                , viewModel.ColumnsConfiguration.ExchangeRateColNumber
                , viewModel.ColumnsConfiguration.ComissionColNumber
                );
            return rawTransactions.Select(line => new Transaction(line));
        }

    }
}
