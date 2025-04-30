using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MCQ_Test;

namespace MCQ_Test
{
    public static class QuestionService
    {
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ratho\source\repos\MCQ_Test\MCQ_Test\question.mdf;Integrated Security=True";

        public static List<Question> GetQuestions(string category)
        {
            List<Question> questions = new List<Question>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TOP 10 * FROM maths WHERE cet = @cet ORDER BY NEWID()";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cet", category);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new Question
                            {
                                Text = reader["que"].ToString(),
                                Options = new string[]
                                {
                                reader["opa"].ToString(),
                                reader["opb"].ToString(),
                                reader["opc"].ToString(),
                                reader["opd"].ToString()
                                },
                                CorrectAnswerText = reader["ans"].ToString()
                            });
                        }
                    }
                }
            }

            return questions;
        }
    }
}