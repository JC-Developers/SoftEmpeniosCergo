﻿using System.ComponentModel;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data.Filtering.Helpers;


namespace SoftEmpenios.Dialogos
{
    public class MyFindPanelFilterHelper
    {

        public MyFindPanelFilterHelper(GridView view)
        {
            _View = view;
            view.CustomRowFilter += new RowFilterEventHandler(view_CustomRowFilter);
        }

        string lastCriteria;
        ExpressionEvaluator lastEvaluator;
        private GridView _View;
        private ExpressionEvaluator GetExpressionEvaluator(CriteriaOperator criteria)
        {
            if (criteria.ToString() == lastCriteria)
                return lastEvaluator;
            lastCriteria = criteria.ToString();
            PropertyDescriptorCollection pdc = ((ITypedList)_View.DataSource).GetItemProperties(null);
            lastEvaluator = new ExpressionEvaluator(pdc, criteria, false);
            return lastEvaluator;
        }

        private CriteriaOperator GetFindPanelCriteria()
        {
            CriteriaOperator criteria = FilterCriteriaHelper.MyConvertFindPanelTextToCriteriaOperator(_View);
            return criteria;
        }
        void view_CustomRowFilter(object sender, RowFilterEventArgs e)
        {
            if (string.IsNullOrEmpty(_View.FindFilterText))
                return;
            CriteriaOperator criteria = FilterCriteriaHelper.ReplaceFindPanelCriteria(_View.DataController.FilterCriteria, _View, GetFindPanelCriteria());
            ExpressionEvaluator evaluator = GetExpressionEvaluator(criteria);
            e.Handled = true;
            e.Visible = evaluator.Fit((_View.DataSource as DataView)[e.ListSourceRow]);
        }
    }
}
