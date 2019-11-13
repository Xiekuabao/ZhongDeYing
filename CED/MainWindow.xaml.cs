using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using MicrosoftAccessAPI;

namespace CED
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        DataSet1.XueXiJiLuDataTable dbStruct;// = new DataSet1.XueXiJiLuDataTable();
        DataTable dt_all;
        const string dbPath = "db.accdb";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            dbStruct = new DataSet1.XueXiJiLuDataTable();
            dt_all = DataBaseProcess.database_read(dbPath, dbStruct.TableName);
            DsG_All.DataContext = dt_all;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string m_searchkeyword = "";
        public string m_SearchKeyword
        {
            get => m_searchkeyword; set
            {
                if (m_searchkeyword != value)
                {
                    m_searchkeyword = value;
                    OnPropertyChanged();
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Btn_Search(object sender, RoutedEventArgs e)
        {
            var key = TB_Keyword.Text;
            if (string.IsNullOrEmpty(key))
            {
                if (dt_all != null)
                {
                    dt_all.Dispose();
                    dt_all = null;
                }
                dt_all = DataBaseProcess.database_read(dbPath, dbStruct.TableName);
                DsG_All.DataContext = dt_all;
            }
            else
            {
                string language;
                if (RB_DeYu.IsChecked == true)
                    language = dbStruct.DeYuColumn.ColumnName;
                else if (RB_YingYu.IsChecked == true)
                    language = dbStruct.YingYuColumn.ColumnName;
                else
                    language = dbStruct.ZhongWenColumn.ColumnName;
                if (dt_all != null)
                {
                    dt_all.Dispose();
                    dt_all = null;
                }
                dt_all = DataBaseProcess.database_read(dbPath, dbStruct.TableName, language, key);
                DsG_All.DataContext = dt_all;
            }
        }

        #region Binding Properties

        private DataRow dr_selected;
        public DataRow DR_Selected
        {
            get => dr_selected;
            set
            {
                if(dr_selected!=value)
                {
                    dr_selected = value;
                    if(dr_selected!=null)
                    {
                        _ZhongWen = dr_selected[dbStruct.ZhongWenColumn.ColumnName].ToString();
                        _YingYu = dr_selected[dbStruct.YingYuColumn.ColumnName].ToString();
                        _DeYu = dr_selected[dbStruct.DeYuColumn.ColumnName].ToString();
                    }
                    else
                    {
                        _ZhongWen = "";
                        _YingYu = "";
                        _DeYu = "";
                    }
                }
            }
        }

        private string m_zhongwen;
        public string _ZhongWen
        {
            get => m_zhongwen;
            set
            {
                if(m_zhongwen!=value)
                {
                    m_zhongwen = value;
                    OnPropertyChanged();
                }
            }
        }

        private string m_yingyu;
        public string _YingYu
        {
            get => m_yingyu;
            set
            {
                if (m_yingyu != value)
                {
                    m_yingyu = value;
                    OnPropertyChanged();
                }
            }
        }

        private string m_deyu;
        public string _DeYu
        {
            get => m_deyu;
            set
            {
                if (m_deyu != value)
                {
                    m_deyu = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        private void DsG_All_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DsG_All.SelectedItem is DataRowView)
            {
                DR_Selected = (DsG_All.SelectedItem as DataRowView).Row;
            }
            else
                DR_Selected = null;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            var dr = dt_all.NewRow();
            dr[dbStruct.ZhongWenColumn.ColumnName] = _ZhongWen;
            dr[dbStruct.YingYuColumn.ColumnName] = _YingYu;
            dr[dbStruct.DeYuColumn.ColumnName] = _DeYu;
            dt_all.Rows.Add(dr);
            if (!DataBaseProcess.database_update(dbPath, dbStruct.TableName, dt_all))
            {
                ;
            }
            else
            {
                DsG_All.SelectedIndex = dt_all.Rows.IndexOf(dr);
                DsG_All.ScrollIntoView(DsG_All.SelectedItem);
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (DR_Selected != null)
            {
                int deletedindex = DsG_All.SelectedIndex;
                DR_Selected.Delete();
                if (!DataBaseProcess.database_update(dbPath, dbStruct.TableName, dt_all))
                {
                    ;
                }
                else
                {
                    if (deletedindex>1)
                    {
                        DsG_All.SelectedIndex = deletedindex == dt_all.Rows.Count ? deletedindex - 1 : deletedindex;
                        DsG_All.ScrollIntoView(DsG_All.SelectedItem);
                    }
                }
            }
        }
    }
}
