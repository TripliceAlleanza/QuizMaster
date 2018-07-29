using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaster___SharedLibrary.QuizModel;
using LiteDB;


/*
 *Dear maintainer:
 *
 *Once you are done trying to 'optimize' this routine,
 *and have realized what a terrible mistake that was,
 *please increment the following counter as a warning
 *to the next guy:
 *
 *total_hours_wasted_here = 7H 51M
 */
 //P.S the counter includes the time wasted in 'QuizModel' 

namespace QuizMaster___Server.Models {

	public interface IPuzzleModelService {
		IList<QuizFormat> Puzzles { get; }
	}

	public class PuzzleModelService : IPuzzleModelService {
		private const string DB_FOLDER_NAME = @"\QuizMasterDB";
		public static string DB_DEPLOYED_QUIZ = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{DB_FOLDER_NAME}\\DeployedQuiz.db";
		public static string DB_UNDEPLOYED_QUIZ = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{DB_FOLDER_NAME}\\UnDeployedQuiz.db";

		public List<QuizFormat> puzzles;

		public IList<QuizFormat> Puzzles => puzzles; // generalizzazione per rispettare la interface

		public PuzzleModelService() {
			puzzles = GetFromDB();

		}

		public PuzzleModelService(IEnumerable<QuizFormat> puzzles) {
			this.puzzles = puzzles.ToList();
		}

		private List<QuizFormat> GetFromDB() {
			throw new NotImplementedException();
		}

		private void AddToDB(QuizFormat quiz) {
			throw new NotImplementedException();
		}

		private void EditInDB(int id, QuizFormat newQuiz) {
			throw new NotImplementedException();
		}

		private void EditInDB(QuizFormat old, QuizFormat newQuiz) {
			throw new NotImplementedException();
		}

		private void RemoveFromDB(int id) {
			throw new NotImplementedException();
		}

		private void RemoveFromDB(QuizFormat quiz) {
			throw new NotImplementedException();
			
		}

		public static void CheckMainDirectoryPath() {
			string MyDocuments_directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			//if there is no directory called as the "DB_FOLDER_NAME"'value then it will create it
			if (!System.IO.Directory.Exists(MyDocuments_directory + DB_FOLDER_NAME))
				System.IO.Directory.CreateDirectory(MyDocuments_directory + DB_FOLDER_NAME);
		}

	}
}
