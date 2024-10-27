using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Form_ModelDB_softeng.Models;


namespace Form_ModelDB_softeng.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly FormContext _context;

        public FormController(FormContext context)
        {
            _context = context;
        }


        //TASK 1: one correct answer
        //this is same as sql query: select * from Question where Id= {questionId}
        //                           select * from Alternatives where QuestionId= {questionId} and IsCorrect=1;

        [HttpGet("SingleCorrect/{questionId}")]
        public IActionResult GetSingleCorrectAlternative( int questionId) { 
            var question=_context.Questions.Include(question => question.Id)// join in sql
                                           .FirstOrDefault(question => question.Id == questionId);//select * from questions where Id= {questionId}
            if (question == null) { return NotFound("Not found"); 
            
            };

            var correctAnswer= question.Alternatives.FirstOrDefault(answer => answer.IsCorrect);
            if (correctAnswer == null)  return NotFound("Not found") ;
            return Ok(correctAnswer);
        }



        //TASK 2: multiple correct answers
        //this is same as sql query: select * from questions join alternativeson  Questions.Id= Alternatives.QuestionId where Questions.Id={questionId)
        //                           select * from alternatives where QuestionId= {questionId} and IsCorrect=1;

        [HttpGet("MultipleCorrect/{questionId}")]
        public IActionResult GetMultipleCorrectAlternatives(int questionId)
        {
            var question_ = _context.Questions.Include(question => question.Alternatives)
                                             .FirstOrDefault(question => question.Id == questionId);

            if (question_ == null) return NotFound("Not found");

            var correctAnswers = question_.Alternatives.Where(answer => answer.IsCorrect).ToList();
            if (!correctAnswers.Any()) return NotFound("Not found");

            return Ok(correctAnswers);
        }




        //TASK 3: 1-5 range
        //this is same as sql query: select * from Submit where Id= {submitId};
        //                           select Alternative.answer, SubmitAnswer.Score from SubmitAnswer
        //                           join Alternative on SubmitAnswer.AlternativeId= Alternative.Id
        //                           where SubmitAnswer.SubmitId={submitId}
        [HttpGet("Scores/{submitId}")]
        public IActionResult GetScoresForSubmission(int submitId)
        {
            var submission = _context.Submit.Include(submit => submit.SubmitAnswers)
                                            .ThenInclude(sa => sa.Alternative)
                                            .FirstOrDefault(submit => submit.Id == submitId);

            if (submission == null) return NotFound("Not found");

            var scores = submission.SubmitAnswers.Select(sa => new
            {
                Answer = sa.Alternative.answer,
                sa.Score
            }).ToList();

            return Ok(scores);
        }

    }
}

