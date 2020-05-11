using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.Wpf.ViewModels
{
    public class MajorIndexViewModel
    {
        private readonly IMajorIndexService _majorIndexService;

        public MajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }
        public MajorIndex DowJones { get; set; }
        public MajorIndex Nasdaq { get; set; }
        public MajorIndex Sp500 { get; set; }

        public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var viewModel=new MajorIndexViewModel(majorIndexService);
            viewModel.LoadMajorIndexes();
            return viewModel;
        }
        private void LoadMajorIndexes()
        {
              _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
             {
                 if (task.Exception==null)
                 {
                     DowJones = task.Result;
                 }
             }); _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
             {
                 if (task.Exception == null)
                 {
                     Nasdaq = task.Result;
                 }
             }); _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
             {
                 if (task.Exception == null)
                 {
                     Sp500 = task.Result;
                 }
             });
            
        }
    }
}