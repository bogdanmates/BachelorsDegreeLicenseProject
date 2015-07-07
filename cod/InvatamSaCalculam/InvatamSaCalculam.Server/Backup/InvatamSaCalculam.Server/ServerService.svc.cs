using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Windows.Forms;
using InvatamSaCalculam.Server.Infrastructure;
using InvatamSaCalculam.Server.Models;

namespace InvatamSaCalculam.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServerService : IServerService
    {
        public int? Login(string username, string password)
        {
            var user = BusinessStructure.Instance.Model.Users.FirstOrDefault(item => item.Username.Equals(username));
            if (user == null)
            {
                return null;
            }
            if (user.Password.Equals(password))
            {
                return user.Id;
            }
            return 0;
        }

        public bool Register(string username, string password, bool isTeacher, string teacherName)
        {
            var user = BusinessStructure.Instance.Model.Users.FirstOrDefault(item => item.Username.Equals(username));
            if (user != null)
            {
                return false;
            }

            User newUser = new User();
            newUser.Username = username;
            newUser.Password = password;
            newUser.IsTeacher = isTeacher;
            if (!isTeacher)
            {
                User teacher = BusinessStructure.Instance.Model.Users.First(item => item.Username.Equals(teacherName));
                newUser.TeacherId = teacher.Id;
            }
            BusinessStructure.Instance.Model.Users.AddObject(newUser);

            UserScore userScore = new UserScore();
            userScore.Score = 0;
            userScore.User = newUser;
            BusinessStructure.Instance.Model.UserScores.AddObject(userScore);

            UserSmallMedal userSmallMedal = new UserSmallMedal();
            userSmallMedal.GoldMedals = 0;
            userSmallMedal.SilverMedals = 0;
            userSmallMedal.BronzeMedals = 0;
            userSmallMedal.User = newUser;
            BusinessStructure.Instance.Model.UserSmallMedals.AddObject(userSmallMedal);

            UserBigMedal userBigMedal = new UserBigMedal();
            userBigMedal.GoldMedals = 0;
            userBigMedal.SilverMedals = 0;
            userBigMedal.BronzeMedals = 0;
            userBigMedal.User = newUser;
            BusinessStructure.Instance.Model.UserBigMedals.AddObject(userBigMedal);

            UserCup userCup = new UserCup();
            userCup.AddCup = 0;
            userCup.DiffCup = 0;
            userCup.DivCup = 0;
            userCup.MulCup = 0;
            userScore.User = newUser;
            BusinessStructure.Instance.Model.UserCups.AddObject(userCup);

            UserGame userGame = new UserGame();
            userGame.Hangman = 0;
            userGame.Blocks = 0;
            userScore.User = newUser;
            BusinessStructure.Instance.Model.UserGames.AddObject(userGame);

            BusinessStructure.Instance.Model.SaveChanges();

            return true;
        }

        public void AddCup(string operationString, int userId)
        {
            Operations operation = (Operations)Enum.Parse(typeof(Operations), operationString);
            UserCup userCup = BusinessStructure.Instance.Model.UserCups.First(item => item.UserId == userId);
            UserScore userScore = BusinessStructure.Instance.Model.UserScores.First(item => item.UserId == userId);
            userScore.Score += 100;
            switch (operation)
            {
                case Operations.Add:
                    userCup.AddCup++;
                    break;
                case Operations.Diff:
                    userCup.DiffCup++;
                    break;
                case Operations.Div:
                    userCup.DivCup++;
                    break;
                case Operations.Mul:
                    userCup.MulCup++;
                    break;
            }
            BusinessStructure.Instance.Model.SaveChanges();
        }

        public void AddMedal(int puzzleSize, int medalType, int points, int userId)
        {
            UserScore userScore = BusinessStructure.Instance.Model.UserScores.First(item => item.UserId == userId);
            userScore.Score += points;
            if (puzzleSize == 1)
            {
                UserSmallMedal userSmallMedal = BusinessStructure.Instance.Model.UserSmallMedals.First(item => item.UserId == userId);
                switch (medalType)
                {
                    case 1:
                        userSmallMedal.GoldMedals++;
                        break;
                    case 2:
                        userSmallMedal.SilverMedals++;
                        break;
                    case 3:
                        userSmallMedal.BronzeMedals++;
                        break;
                }
            }
            else
            {
                UserBigMedal userBigMedal = BusinessStructure.Instance.Model.UserBigMedals.First(item => item.UserId == userId);
                switch (medalType)
                {
                    case 1:
                        userBigMedal.GoldMedals++;
                        break;
                    case 2:
                        userBigMedal.SilverMedals++;
                        break;
                    case 3:
                        userBigMedal.BronzeMedals++;
                        break;
                }
            }
            BusinessStructure.Instance.Model.SaveChanges();
        }

        public bool IsTeacher(int userId)
        {
            User user = BusinessStructure.Instance.Model.Users.First(item => item.Id == userId);
            return user.IsTeacher != null && (bool)user.IsTeacher;
        }

        public long GetScore(int userId)
        {
            return BusinessStructure.Instance.Model.UserScores.First(item => item.Id == userId).Score;
        }

        public int GetCup(string operationString, int userId)
        {
            Operations operation = (Operations)Enum.Parse(typeof(Operations), operationString);
            UserCup userCup = BusinessStructure.Instance.Model.UserCups.First(item => item.UserId == userId);
            switch (operation)
            {
                case Operations.Add:
                    return userCup.AddCup;
                case Operations.Diff:
                    return userCup.DiffCup;
                case Operations.Div:
                    return userCup.DivCup;
                case Operations.Mul:
                    return userCup.MulCup;
                default:
                    return 0;
            }
        }

        public int GetMedal(int puzzleSize, int medalType, int userId)
        {
            if (puzzleSize == 1)
            {
                UserSmallMedal userSmallMedal = BusinessStructure.Instance.Model.UserSmallMedals.First(item => item.UserId == userId);
                switch (medalType)
                {
                    case 1:
                        return userSmallMedal.GoldMedals;
                    case 2:
                        return userSmallMedal.SilverMedals;
                    case 3:
                        return userSmallMedal.BronzeMedals;
                    default:
                        return 0;
                }
            }
            else
            {
                UserBigMedal userBigMedal = BusinessStructure.Instance.Model.UserBigMedals.First(item => item.UserId == userId);
                switch (medalType)
                {
                    case 1:
                        return userBigMedal.GoldMedals;
                    case 2:
                        return userBigMedal.SilverMedals;
                    case 3:
                        return userBigMedal.BronzeMedals;
                    default:
                        return 0;
                }
            }
        }

        public List<User> GetTopPlayers()
        {
            return BusinessStructure.Instance.Model.Users.Where(item => item.IsTeacher == false).OrderByDescending(item => item.UserScores.FirstOrDefault().Score).Take(10).ToList();
        }

        public int GetBlocksScore(int userId)
        {
            UserGame userGame = BusinessStructure.Instance.Model.UserGames.First(item => item.UserId == userId);
            return userGame.Blocks;
        }

        public int GetHangmanScore(int userId)
        {
            UserGame userGame = BusinessStructure.Instance.Model.UserGames.First(item => item.UserId == userId);
            return userGame.Hangman;
        }

        public void SetBlocksScore(int score, int userId)
        {
            UserGame userGame = BusinessStructure.Instance.Model.UserGames.First(item => item.UserId == userId);
            userGame.Blocks = score;
            BusinessStructure.Instance.Model.SaveChanges();
        }

        public void SetHangmanScore(int score, int userId)
        {
            UserGame userGame = BusinessStructure.Instance.Model.UserGames.First(item => item.UserId == userId);
            userGame.Hangman = score;
            BusinessStructure.Instance.Model.SaveChanges();
        }

        public void Reset(int userId)
        {
            User user = BusinessStructure.Instance.Model.Users.First(item => item.Id == userId);
            user.UserScores.First().Score = 0;

            UserSmallMedal smallMedals = user.UserSmallMedals.First();
            smallMedals.BronzeMedals = 0;
            smallMedals.SilverMedals = 0;
            smallMedals.GoldMedals = 0;

            UserBigMedal bigMedals = user.UserBigMedals.First();
            bigMedals.BronzeMedals = 0;
            bigMedals.SilverMedals = 0;
            bigMedals.GoldMedals = 0;

            UserCup userCup = user.UserCups.First();
            userCup.AddCup = 0;
            userCup.DiffCup = 0;
            userCup.DivCup = 0;
            userCup.MulCup = 0;

            UserGame userGame = user.UserGames.First();
            userGame.Hangman = 0;
            userGame.Blocks = 0;

            BusinessStructure.Instance.Model.SaveChanges();
        }

        public List<User> GetTeachers()
        {
            return BusinessStructure.Instance.Model.Users.Where(item => item.IsTeacher == true).ToList();
        }

        public List<User> GetTeachersStudents(int teacherId)
        {
            return BusinessStructure.Instance.Model.Users.Where(item => item.TeacherId == teacherId).ToList();
        }

        public void Delete(int userId)
        {
            var user = BusinessStructure.Instance.Model.Users.First(item => item.Id == userId);
            BusinessStructure.Instance.Model.UserSmallMedals.DeleteObject(user.UserSmallMedals.First());
            BusinessStructure.Instance.Model.UserBigMedals.DeleteObject(user.UserBigMedals.First());
            BusinessStructure.Instance.Model.UserCups.DeleteObject(user.UserCups.First());
            BusinessStructure.Instance.Model.UserGames.DeleteObject(user.UserGames.First());
            BusinessStructure.Instance.Model.UserScores.DeleteObject(user.UserScores.First());
            BusinessStructure.Instance.Model.Users.DeleteObject(user);
            BusinessStructure.Instance.Model.SaveChanges();
        }

        public void CheckConnection()
        {

        }
    }
}
