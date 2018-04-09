using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizMaster___SharedLibrary.QuizModel;

namespace QuizMaster___Server.Models {

	public interface IPuzzleModelService {
		IList<QuizFormat> Puzzles { get; } 
	}


	public class PuzzleModelService : IPuzzleModelService {

		public static string DB_PATH = "./database.porcodio"; // TODO Sistema ma non crearmi roba sul desktop!

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


	}
}
