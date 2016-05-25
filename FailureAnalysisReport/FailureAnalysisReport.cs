using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FailureAnalysisReport
{
    public partial class FailureAnalysisReport : Form
    {
        string connection_string = "Server=ATI-SQL;Database=uniPoint_Live;UID=jbread;PWD=Cloudy2Day";
        private BindingSource bindingSource = new BindingSource();
        enum ButtonType { NCData, CPAData, ViewHours,  Combined};
        private ButtonType lastButtonClicked = ButtonType.NCData;


        public FailureAnalysisReport()
        {
            InitializeComponent();
        }

        private void FailureAnalysisReport_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = bindingSource;
            dataGridView.ReadOnly = true;

            // initialize dateTime object to a year before today
            startDateTimePicker.Value = DateTime.Now.AddYears(-1);

            // initialize estimated hours to 2000 and disable
            estimatedHoursTextBox.Text = "2000";
            estimatedHoursTextBox.Enabled = false;
        }

        private void ncDataButton_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT NCR, Investigated_by AS 'Investigated By', Investigation_hrs AS 'Investigation Hours', Material AS 'Part No', ncT.Job AS 'Job', Investigation_date AS 'Investigation Date' , Investigation_complete AS 'Investigation Complete', Origin_ref AS 'Origin Reference', Origin_cause AS 'Origin Cause', Origin_category AS 'Origin Category', tT.Notes AS 'Investigation Notes'\n" +
                "FROM uniPoint_Live.dbo.PT_NC AS ncT\n" +
                "LEFT JOIN uniPoint_Live.dbo.PT_Task AS tT\n" +
                "ON tT.TaskType = 'NC' AND tT.TaskTypeID = NCR AND tT.TaskSubType = 'Investigation'\n" +
                "WHERE CONVERT(DATE, NCR_Date) > CONVERT(Date, '" + startDateTimePicker.Value.ToShortDateString() + "') AND  CONVERT(DATE, NCR_Date) <= CONVERT(Date, '" + endDateTimePicker.Value.ToShortDateString() + "')\n" +
                "ORDER BY NCR;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection_string);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            bindingSource.DataSource = dt;

            // update Rows label
            rowsLabel.Text = "Rows: " + dt.Rows.Count;

            // update last button clicked
            lastButtonClicked = ButtonType.NCData;

            // estimated hours disable
            estimatedHoursTextBox.Enabled = false;
        }

        private void cpaDataButton_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT CPA_no AS 'CPA', Investigation_by AS 'Investigated By', Investigation_hrs AS 'Investigation Hours', cpT.Description AS 'Part No/ Description', Investigation_date AS 'Investigation Date', Investigation_complete AS 'Investigation Complete', Origin_ref AS 'Origin Reference', Origin_cause AS 'Origin Cause', Origin_category AS 'Origin Category', tT.Notes AS 'Investigation Notes'\n" +
                "FROM uniPoint_Live.dbo.PT_CPA AS cpT\n" +
                "LEFT JOIN uniPoint_Live.dbo.PT_Task AS tT\n" +
                "ON tT.TaskType = 'CPA' AND tT.TaskTypeID = CPA_no AND tT.TaskSubType = 'Investigation'\n" +
                "WHERE CONVERT(DATE, CPA_date) > CONVERT(Date, '" + startDateTimePicker.Value.ToShortDateString() + "') AND  CONVERT(DATE, CPA_date) <= CONVERT(Date, '" + endDateTimePicker.Value.ToShortDateString() + "')\n" +
                "ORDER BY CPA_no;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection_string);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            bindingSource.DataSource = dt;

            // update Rows label
            rowsLabel.Text = "Rows: " + dt.Rows.Count;

            // update last button clicked
            lastButtonClicked = ButtonType.CPAData;

            // estimated hours disable
            estimatedHoursTextBox.Enabled = false;
        }


        private void ViewHoursButton_Click(object sender, EventArgs e)
        {
            // check if empty textbox
            if (estimatedHoursTextBox.Text.Length == 0)
                return;

            // check that estimated total hours contains an integer
            int estimatedHours = -100;
            if (!int.TryParse(estimatedHoursTextBox.Text, out estimatedHours) || estimatedHours < 0)
            {
                MessageBox.Show("Invalid number of estimated hours");
                return;
            }

            string query =
                "SELECT Investigator AS 'Investigated By', CONVERT(DECIMAL(18,2), SUM(hours)) AS 'Total Hours', " + estimatedHours + " AS 'Estimated Total Hours', CONVERT(varchar, CONVERT(DECIMAL(18,2), (CONVERT(DECIMAL, SUM(hours))/" + estimatedHours + ")*100)) + '%' AS Percentage, (CASE WHEN (CONVERT(DECIMAL, SUM(hours))/" + estimatedHours + ") > 0.01 THEN CONVERT(varchar, CONVERT(DECIMAL(18), ROUND((CONVERT(DECIMAL, SUM(hours))/" + estimatedHours + ")*100, 0))) + '%' ELSE '0%' END) AS 'Post-Threshold Percentage for Failure Analysis Lab'\n" +
                "FROM\n" +
                "(SELECT Investigated_by AS Investigator, Investigation_hrs AS hours FROM uniPoint_Live.dbo.PT_NC\n" +
                "WHERE CONVERT(DATE, NCR_Date) > CONVERT(Date, '" + startDateTimePicker.Value.ToShortDateString() + "') AND  CONVERT(DATE, NCR_Date) <= CONVERT(Date, '" + endDateTimePicker.Value.ToShortDateString() + "')\n" +
                "UNION ALL\n" +
                "SELECT Investigation_by AS Investigator, Investigation_hrs AS hours FROM uniPoint_Live.dbo.PT_CPA\n" +
                "WHERE CONVERT(DATE, CPA_date) > CONVERT(Date, '" + startDateTimePicker.Value.ToShortDateString() + "') AND  CONVERT(DATE, CPA_date) <= CONVERT(Date, '" + endDateTimePicker.Value.ToShortDateString() + "')\n" +
                ") AS combinedT\n" +
                "WHERE Investigator IS NOT NULL\n" +
                "GROUP BY Investigator\n" +
                "ORDER BY Investigator;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection_string);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dt.Rows.Add();
            dt.Rows[dt.Rows.Count - 1].SetField(0, "Total");

            double total = 0;
            for(int i = 0; i < dt.Rows.Count - 1; i++)
            {
                total += double.Parse(dt.Rows[i][1].ToString());
            }
            dt.Rows[dt.Rows.Count - 1].SetField(1, total);
            bindingSource.DataSource = dt;

            // update Rows label
            rowsLabel.Text = "Rows: " + dt.Rows.Count;

            // update last button clicked
            lastButtonClicked = ButtonType.ViewHours;

            // enable estimated hours
            estimatedHoursTextBox.Enabled = true;
        }



        private void combinedTimeTrackingButton_Click(object sender, EventArgs e)
        {
            string query =
                "SELECT TrackingProgram AS 'Tracking Program', nccpaNum AS 'NC# / CPA#', Investigator AS 'Investigated By', firstLetterOfFirstName AS 'First Letter of First Name', lastName AS 'Last Name', hours AS 'Investigation Hours', partNum AS 'Part #', Job AS Job, investigationDate AS 'Investigation Date', investigationComplete AS 'Investigation Complete', originRef AS 'Origin Reference', originCause AS 'Origin Cause', originCategory AS 'Origin Category', Notes\n" +
                "FROM\n" +
                "(SELECT 'NC' AS TrackingProgram, NCR AS nccpaNum, Investigated_by AS Investigator, LEFT(Investigated_by, 1) AS firstLetterOfFirstName, SUBSTRING(Investigated_by, 2, LEN(Investigated_by) - 1) AS lastName,Investigation_hrs AS hours, Material AS partNum, Job AS Job, Investigation_date AS investigationDate, Investigation_complete AS investigationComplete, Origin_ref AS originRef, Origin_cause AS originCause, Origin_category AS originCategory, tT.Notes AS notes FROM uniPoint_Live.dbo.PT_NC\n" +
                "LEFT JOIN uniPoint_Live.dbo.PT_Task AS tT\n" +
                "ON tT.TaskType = 'NC' AND tT.TaskTypeID = NCR AND tT.TaskSubType = 'Investigation'\n" +
                "WHERE CONVERT(DATE, NCR_Date) > CONVERT(Date, '" + startDateTimePicker.Value.ToShortDateString() + "') AND  CONVERT(DATE, NCR_Date) <= CONVERT(Date, '" + endDateTimePicker.Value.ToShortDateString() + "')\n" +
                "UNION ALL\n" +
                "SELECT 'CPA' AS TrackingProgram, CPA_no AS nccpaNum, Investigation_by AS Investigator, LEFT(Investigation_by, 1) AS firstLetterOfFirstName, SUBSTRING(Investigation_by, 2, LEN(Investigation_by) - 1) AS lastName,Investigation_hrs AS hours, cpT.Description AS partNum, 'Not Part of CPA Data' AS Job, Investigation_date AS investigationDate, Investigation_complete AS investigationComplete, Origin_ref AS originRef, Origin_cause AS originCause, Origin_category AS originCategory, tT.Notes AS notes FROM uniPoint_Live.dbo.PT_CPA AS cpT\n" +
                "LEFT JOIN uniPoint_Live.dbo.PT_Task AS tT\n" +
                "ON tT.TaskType = 'CPA' AND tT.TaskTypeID = CPA_no AND tT.TaskSubType = 'Investigation'\n" +
                "WHERE CONVERT(DATE, CPA_date) > CONVERT(Date, '" + startDateTimePicker.Value.ToShortDateString() + "') AND  CONVERT(DATE, CPA_date) <= CONVERT(Date, '" + endDateTimePicker.Value.ToShortDateString() + "')\n" +
                ") AS combinedT\n" +
                "ORDER BY [Tracking Program], nccpaNum;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection_string);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            bindingSource.DataSource = dt;

            // update Rows label
            rowsLabel.Text = "Rows: " + dt.Rows.Count;

            // update last button clicked
            lastButtonClicked = ButtonType.Combined;

            // disable
            estimatedHoursTextBox.Enabled = false;
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            switch (lastButtonClicked)
            {
                case ButtonType.NCData:
                    ncDataButton_Click(new object(), new EventArgs());
                    break;
                case ButtonType.CPAData:
                    cpaDataButton_Click(new object(), new EventArgs());
                    break;
                case ButtonType.ViewHours:
                    ViewHoursButton_Click(new object(), new EventArgs());
                    break;
                case ButtonType.Combined:
                    combinedTimeTrackingButton_Click(new object(), new EventArgs());
                    break;
            }
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            switch (lastButtonClicked)
            {
                case ButtonType.NCData:
                    ncDataButton_Click(new object(), new EventArgs());
                    break;
                case ButtonType.CPAData:
                    cpaDataButton_Click(new object(), new EventArgs());
                    break;
                case ButtonType.ViewHours:
                    ViewHoursButton_Click(new object(), new EventArgs());
                    break;
                case ButtonType.Combined:
                    combinedTimeTrackingButton_Click(new object(), new EventArgs());
                    break;
            }
        }

        private void estimatedHoursTextBox_TextChanged(object sender, EventArgs e)
        {
            if (lastButtonClicked == ButtonType.ViewHours)
                ViewHoursButton_Click(new object(), new EventArgs());
        }
    }
}
