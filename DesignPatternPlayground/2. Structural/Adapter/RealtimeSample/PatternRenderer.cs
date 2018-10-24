using System.Collections.Generic;
using System.Data;
using System.IO;

namespace DesignPatternPlayground_Creational.RealtimeSample
{
    public class PatternRenderer
    {
    private readonly IDataPatterRendererAdapter _dataPatterRendererAdapter;

        public PatternRenderer(IDataPatterRendererAdapter dataPatterRenderer)
        {
            _dataPatterRendererAdapter = dataPatterRenderer;
        }

        }

    public interface IDataPatterRendererAdapter
    {
        string ListPatterns(IEnumerable<Pattern> patterns);
    }

    public class DataPatternRendererAdapter:IDataPatterRendererAdapter
    {
        private DataRenderer _dataRenderer;
        public string ListPatterns(IEnumerable<Pattern> patterns)
        {
            var adapter = new DataPatternRendererDbAdapter(patterns);
            _dataRenderer = new DataRenderer(adapter);
            var writer = new StringWriter();
            _dataRenderer.Render(writer);
            return writer.ToString();
        }
    }

    public class DataPatternRendererDbAdapter :IDbDataAdapter
    {
        private readonly IEnumerable<Pattern> _patterns;
        public DataPatternRendererDbAdapter(IEnumerable<Pattern> patterns)
        {
            _patterns = patterns;
        }

        public int Fill(DataSet dataSet)
        {
            var myDataTable = new DataTable();
            myDataTable.Columns.Add(new DataColumn("Id", typeof(int)));
            myDataTable.Columns.Add(new DataColumn("Name", typeof(string)));
            myDataTable.Columns.Add(new DataColumn("Description", typeof(string)));

            foreach (var pattern in _patterns)
            {
                var myRow = myDataTable.NewRow();
                myRow[0] = pattern.Id;
                myRow[1] = pattern.Name;
                myRow[2] = pattern.Description;
                myDataTable.Rows.Add(myRow);
            }
            dataSet.Tables.Add(myDataTable);
            dataSet.AcceptChanges();

            return myDataTable.Rows.Count;
        }

        #region Not implemented

        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            throw new System.NotImplementedException();
        }



        public IDataParameter[] GetFillParameters()
        {
            throw new System.NotImplementedException();
        }

        public int Update(DataSet dataSet)
        {
            throw new System.NotImplementedException();
        }

        public MissingMappingAction MissingMappingAction { get; set; }
        public MissingSchemaAction MissingSchemaAction { get; set; }
        public ITableMappingCollection TableMappings { get; }


        public IDbCommand SelectCommand { get; set; }
        public IDbCommand InsertCommand { get; set; }
        public IDbCommand UpdateCommand { get; set; }
        public IDbCommand DeleteCommand { get; set; }
        #endregion

    }
}