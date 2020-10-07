using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerSideCRUD.Data.Context;
using BlazorServerSideCRUD.Models.Survey;

namespace BlazorServerSideCRUD.Data.Service
{
    public class SurveyService
    {
        SurveyDbContext _context;
        public SurveyService(SurveyDbContext context)
        {
            _context = context;
        }

        #region Question
        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question> InsertQuestionAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return question;
        }

        public async Task<Question> UpdateQuestionAsync(string id, Question s)
        {
            var question = await _context.Questions.FindAsync(id);

            if (question == null)
                return null;

            question.Text = s.Text;
            question.QuestionType = s.QuestionType;
            question.Options = s.Options;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return question;
        }

        public async Task<Question> DeleteQuestionAsync(string id)
        {
            var student = await _context.Questions.FindAsync(id);

            if (student == null)
                return null;

            _context.Questions.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return _context.Questions.Any(e => e.ID == id);
        }
        #endregion Question

        #region Surveys 
        public async Task<List<Survey>> GetSurveysAsync() => await _context.Surveys.ToListAsync();

        public async Task<Survey> GetSurveyByIdAsync(int id) => await _context.Surveys.FindAsync(id);

        public async Task<Survey> InsertSurveyAsync(Survey survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();

            return survey;
        }

        public async Task<Survey> UpdateSurveyAsync(string id, Survey s)
        {
            var survey = await _context.Surveys.FindAsync(id);

            if (survey == null)
                return null;

            survey.Title = s.Title;
            survey.Description = s.Description;
            survey.CreatedOn = s.CreatedOn;
            survey.ExpiresOn = s.ExpiresOn;
            survey.CreatedBy = s.CreatedBy;

            _context.Surveys.Update(survey);
            await _context.SaveChangesAsync();

            return survey;
        }

        public async Task<Survey> DeleteSurveyAsync(string id)
        {
            var survey = await _context.Surveys.FindAsync(id);

            if (survey == null)
                return null;

            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();

            return survey;
        }

        private bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.ID == id);
        }
        #endregion Surveys
        #region Users
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateUserAsync(string id, User s)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            user.FirstName = s.FirstName;
            user.LastName = s.LastName;
            user.UserName = s.UserName;
            user.Password = s.Password;
            user.Role = s.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
        #endregion Users
    }
}
