using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.Wpf.ViewModels
{
    public class MajorIndexListingViewModel:ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;
        private MajorIndex _dowJones;
        private MajorIndex _nasdaq;
        private MajorIndex _sp500;

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndex DowJones
        {
            get => _dowJones;
            set
            {
                if (Equals(value, _dowJones)) return;
                _dowJones = value;
                OnPropertyChanged();
            }
        }

        public MajorIndex Nasdaq
        {
            get => _nasdaq;
            set
            {
                if (Equals(value, _nasdaq)) return;
                _nasdaq = value;
                OnPropertyChanged();
            }
        }

        public MajorIndex Sp500
        {
            get => _sp500;
            set
            {
                if (Equals(value, _sp500)) return;
                _sp500 = value;
                OnPropertyChanged();
            }
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var viewModel=new MajorIndexListingViewModel(majorIndexService);
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