
using System;
using System.Data;
using System.Data.SQLite;

namespace AssistyWin
{
    public static class DatabaseHelper
    {
        private static readonly string  connectionString = @"Data Source=C:\\FIS Project\\ASSISTY.db;";
 

        public static SQLiteConnection GetConnection() => new SQLiteConnection(connectionString);

        public static DataTable ExecuteQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                using (var adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
    }

    // Users
    public class User
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM Users");
        public static int Add(string username, string email, string role, string createdAt)
        {
            string q = $"INSERT INTO Users (username, email, role, created_at) VALUES ('{username}', '{email}', '{role}', '{createdAt}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // SystemConfig
    public class SystemConfig
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM SystemConfig");
        public static int Update(string key, string value)
        {
            string q = $"UPDATE SystemConfig SET Value = '{value}' WHERE Key = '{key}'";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // Counterparties
    public class Counterparty
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM Counterparties");
        public static int Add(string code, int isConfigured, string createdAt)
        {
            string q = $"INSERT INTO Counterparties (CounterpartyCode, IsConfigured, CreatedAt) VALUES ('{code}', {isConfigured}, '{createdAt}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
        public static int Update(string code, int isConfigured)
        {
            string q = $"UPDATE Counterparties SET IsConfigured = {isConfigured} WHERE CounterpartyCode = '{code}'";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // AssistyLog
    public class AssistyLogDLA
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM AssistyLog");
        public static int Add(string user, string transaction, string actionType, string description, string timestamp)
        {
            string q = $"INSERT INTO AssistyLog (User, trx, ActionType, Description, Timestamp) VALUES ('{user}', '{transaction}', '{actionType}', '{description}', '{timestamp}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // FISTickets
    public class FISTicketDAL
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM FISTickets");
        public static int Add(string app, string error, string desc, string fix, string resolved, string updated)
        {
            string q = $"INSERT INTO FISTickets (application_name, error_code, description, recommended_fix, Resolved, last_updated) VALUES ('{app}', '{error}', '{desc}', '{fix}', '{resolved}', '{updated}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // Roles
    public class Role
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM Roles");
        public static int Add(string name, string email, string desc)
        {
            string q = $"INSERT INTO Roles (RoleName, RoleEmail, Description) VALUES ('{name}', '{email}', '{desc}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // Actions
    public class ActionLog
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM Actions");
        public static int Add(string name, string detail)
        {
            string q = $"INSERT INTO Actions (ActionName, ActionDetail) VALUES ('{name}', '{detail}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // Feedback
    public class Feedback
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM feedback");
        public static int Add(int issueId, int userId, int resolutionId, int rating, string comments, string submittedAt)
        {
            string q = $"INSERT INTO feedback (issue_id, user_id, resolution_id, rating, comments, submitted_at) VALUES ({issueId}, {userId}, {resolutionId}, {rating}, '{comments}', '{submittedAt}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // Resolutions
    public class Resolution
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM Resolutions");
        public static int Add(int issueId, string recFix, string appFix, string status, string resolvedBy, string resolvedAt)
        {
            string q = $"INSERT INTO Resolutions (issue_id, recommended_fix, applied_fix, resolution_status, resolved_by, resolved_at) VALUES ({issueId}, '{recFix}', '{appFix}', '{status}', '{resolvedBy}', '{resolvedAt}')";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }

    // ResolutionActions
    public class ResolutionAction
    {
        public static DataTable GetAll() => DatabaseHelper.ExecuteQuery("SELECT * FROM ResolutionActions");
        public static int Add(int issueId, int resolutionId, int actionId)
        {
            string q = $"INSERT INTO ResolutionActions (IssueId, ResolutionId, ActionId) VALUES ({issueId}, {resolutionId}, {actionId})";
            return DatabaseHelper.ExecuteNonQuery(q);
        }
    }


    public class Issue
    {
        public static DataTable GetAll()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM Issues");
        }

        public static DataTable GetFiltered(string userId, string status)
        {
            string query = "SELECT * FROM Issues WHERE 1=1";

            if (!string.IsNullOrWhiteSpace(userId))
                query += $" AND user_id = '{userId}'";

            if (!string.IsNullOrWhiteSpace(status))
                query += $" AND status = '{status}'";

            return DatabaseHelper.ExecuteQuery(query);
        }

        public static int Add(string userId, string summary, string status, string createdAt)
        {
            string query = $"INSERT INTO Issues (user_id, summary, status, created_at) VALUES ('{userId}', '{summary}', '{status}', '{createdAt}')";
            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int UpdateStatus(int issueId, string newStatus)
        {
            string query = $"UPDATE Issues SET status = '{newStatus}' WHERE issue_id = {issueId}";
            return DatabaseHelper.ExecuteNonQuery(query);
        }
    }


}