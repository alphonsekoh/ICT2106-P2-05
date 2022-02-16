using PainAssessment.Models;
using System.Collections.Generic;

namespace PainAssessment.Interfaces
{
    interface IDefaultQuestionsService
    {
        // Write all the functions controller can call e.g. CRUD
        IEnumerable<DefaultQuestion> GetAllDefaultQuestions();
        IEnumerable<DefaultQuestion> GetAllDefaultQuestionsFromTemplateChecklist(int templateID);
        DefaultQuestion GetDefaultQuestion(string templateID);
        void CreateDefaultQuestion(int templateID, string questionString, string questionDescription, int painSection, double weightage);
        void UpdateDefaultQuestion(int defaultQuestionID, string questionString, string questionDescription, int painSection, double weightage);
        void DeleteDefaultQuestion(int defaultQuestionID);
    }
}