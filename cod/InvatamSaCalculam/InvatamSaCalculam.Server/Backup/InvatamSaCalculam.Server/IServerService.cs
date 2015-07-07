using System.Collections.Generic;
using System.ServiceModel;
using InvatamSaCalculam.Server.Models;

namespace InvatamSaCalculam.Server
{
    [ServiceContract]
    public interface IServerService
    {
        [OperationContract]
        int? Login(string username, string password);

        [OperationContract]
        bool Register(string username, string password, bool isTeacher, string teacherName);

        [OperationContract]
        bool IsTeacher(int userId);

        [OperationContract]
        long GetScore(int userId);

        [OperationContract]
        void AddCup(string operationString, int userId);

        [OperationContract]
        void AddMedal(int puzzleSize, int medalType, int points, int userId);

        [OperationContract]
        int GetCup(string operationString, int userId);

        [OperationContract]
        int GetMedal(int puzzleSize, int medalType, int userId);

        [OperationContract]
        List<User> GetTopPlayers();

        [OperationContract]
        int GetBlocksScore(int userId);

        [OperationContract]
        int GetHangmanScore(int userId);

        [OperationContract]
        void SetBlocksScore(int score, int userId);

        [OperationContract]
        void SetHangmanScore(int score, int userId);

        [OperationContract]
        void Reset(int userId);

        [OperationContract]
        List<User> GetTeachers();

        [OperationContract]
        List<User> GetTeachersStudents(int teacherId);

        [OperationContract]
        void Delete(int userId);

        [OperationContract]
        void CheckConnection();
    }
}
