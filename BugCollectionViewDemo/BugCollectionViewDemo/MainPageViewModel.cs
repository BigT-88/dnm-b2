using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BugCollectionViewDemo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand DetailsToggleCommand { private set; get; }
        public ICommand DetailsOpenCommand { private set; get; }
        public ICommand DetailsCloseCommand { private set; get; }

        private ObservableCollection<ListContent> _mainList = new ObservableCollection<ListContent>();
        public ObservableCollection<ListContent> MainList
        {
            get { return _mainList; }
            set
            {
                _mainList = value;
                OnPropertyChanged();
            }
        }

        private bool _isDetailsOpen;
        public bool IsDetailsOpen
        {
            get { return _isDetailsOpen; }
            set
            {
                _isDetailsOpen = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            DetailsToggleCommand = new Command(async (e) => await SelectDetailsToggle(e as ListContent));
            DetailsOpenCommand = new Command(async (e) => await SelectDetailsOpen(e as ListContent));
            DetailsCloseCommand = new Command(async (e) => await SelectDetailsClose(e as ListContent));
            _isDetailsOpen = false;
            LoadCollection();
        }

        private void LoadCollection()
        {
            _mainList.Add(new ListContent { ColumnA = "Item 1", ColumnB = "Type A", ColumnC = "Option A", Detail1 = "AAAAAAAA", Detail2 = "aaaaaaaa", Detail3 = "A1A1A1A1", Detail4 = "a1a1a1a1" });
            _mainList.Add(new ListContent { ColumnA = "Item 2", ColumnB = "Type B", ColumnC = "Option B", Detail1 = "BBBBBBBB", Detail2 = "bbbbbbbb", Detail3 = "B2B2B2B2", Detail4 = "b2b2b2b2" });
            _mainList.Add(new ListContent { ColumnA = "Item 3", ColumnB = "Type C", ColumnC = "Option C", Detail1 = "CCCCCCCC", Detail2 = "cccccccc", Detail3 = "C3C3C3C3", Detail4 = "c3c3c3c3" });
            _mainList.Add(new ListContent { ColumnA = "Item 4", ColumnB = "Type D", ColumnC = "Option D", Detail1 = "DDDDDDDD", Detail2 = "dddddddd", Detail3 = "D4D4D4D4", Detail4 = "d4d4d4d4" });
            _mainList.Add(new ListContent { ColumnA = "Item 5", ColumnB = "Type E", ColumnC = "Option E", Detail1 = "EEEEEEEE", Detail2 = "eeeeeeee", Detail3 = "E5E5E5E5", Detail4 = "e5e5e5e5" });
            _mainList.Add(new ListContent { ColumnA = "Item 6", ColumnB = "Type F", ColumnC = "Option F", Detail1 = "FFFFFFFF", Detail2 = "ffffffff", Detail3 = "F6F6F6F6", Detail4 = "f6f6f6f6" });
            _mainList.Add(new ListContent { ColumnA = "Item 7", ColumnB = "Type G", ColumnC = "Option G", Detail1 = "GGGGGGGG", Detail2 = "gggggggg", Detail3 = "G7G7G7G7", Detail4 = "g7g7g7g7" });
            _mainList.Add(new ListContent { ColumnA = "Item 8", ColumnB = "Type H", ColumnC = "Option H", Detail1 = "HHHHHHHH", Detail2 = "hhhhhhhh", Detail3 = "H8H8H8H8", Detail4 = "h8h8h8h8" });
        }

        private async Task SelectDetailsToggle(ListContent listContent)
        {
            try
            {
                if (listContent.IsDetailsOpen)
                {
                    await SelectDetailsClose(listContent);
                }
                else
                {
                    await SelectDetailsOpen(listContent);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async Task SelectDetailsOpen(ListContent listContent)
        {
            try
            {
                _isDetailsOpen = true;
                listContent.IsDetailsOpen = true;
            }
            catch (Exception ex)
            {
            }
        }

        private async Task SelectDetailsClose(ListContent listContent)
        {
            try
            {
                _isDetailsOpen = false;
                listContent.IsDetailsOpen = false;
            }
            catch (Exception ex)
            {
            }
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class ListContent : BaseModel
    {
        public string ColumnA { get; set; }
        public string ColumnB { get; set; }
        public string ColumnC { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public string Detail3 { get; set; }
        public string Detail4 { get; set; }
        private bool _isDetailsOpen;
        public bool IsDetailsOpen
        {
            get => _isDetailsOpen;
            set
            {

                _isDetailsOpen = value;
                OnPropertyChanged();
            }
        }
    }

    public class BaseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
