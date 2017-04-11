using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C1.Win.C1FlexGrid;
using Infragistics.Win.UltraWinToolbars;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Ultilities
{
    public class clsXuLyControls
    {
        public static void ThemMoi(C1FlexGrid _flx, int trangthai, UltraToolbarsManager _ultratoolbar, int CotEdit)
        {
            string loi = "";
            try
            {
                loi = "";
                //AnHienDieuKhien(_ultratoolbar, trangthai);
                _flx.Rows.Add();
                _flx.SetUserData(_flx.Rows.Count - 1, 0, "");
                //bo danh dau
                for (int i = 1; i <= _flx.Rows.Count - 1; i++)
                {
                    //loi = _flx.GetUserData(i, 0).ToString();
                    if (string.IsNullOrEmpty(loi) == true)
                    {
                        _flx.Rows[i].Style = null;
                    }
                }
                int k = _flx.Rows.Count - 1;
                _flx.Row = k;
                _flx[_flx.Rows.Count - 1, 0] = _flx.Rows.Count - 1;
                _flx[k, _flx.Cols.Count - 1] = trangthai;
                for (int i = 1; i <= _flx.Cols.Count - 2; i++)
                {
                    _flx[_flx.Rows.Count - 1, i] = "";
                }
                _flx.AllowEditing = true;
                _flx.Rows[_flx.Rows.Count - 1].Selected = true;
                _flx.TopRow = _flx.Rows.Count - 1;
                _flx.StartEditing(_flx.Rows.Count - 1, CotEdit);
                //_flx.Cols[3].Selected = true;
                k = _flx.RowSel;
                int n = _flx.Rows.Count - 1;
                _flx.KeyActionEnter = KeyActionEnum.MoveAcross;
            }
            catch { }
        }
        public static void ThemMoi(C1FlexGrid _flx, int columautovalue, int trangthai, UltraToolbarsManager _ultratoolbar, int CotEdit)
        {
            try
            {
                _flx.Rows.Add();
                for (int i = 1; i < _flx.Cols.Count; i++)
                {
                    if (i == columautovalue)
                    { _flx[_flx.Rows.Count - 1, i] = Guid.NewGuid().ToString(); }
                    else { _flx[_flx.Rows.Count - 1, i] = ""; }
                }
                _flx[_flx.Rows.Count - 1, 0] = (_flx.Rows.Count - 1).ToString();
                _flx.Select(_flx.Rows.Count - 1,1);
                _flx.StartEditing(_flx.Rows.Count - 1, 1);
                _flx.KeyActionEnter = KeyActionEnum.MoveAcross;
            }
            catch { }
        }
    }
}
