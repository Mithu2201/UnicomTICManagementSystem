using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;

namespace UnicomTICManagementSystem.Repository
{
    internal class Migration
    {

        public static void CreateTables()
        {
            using (var conn = Dbconfig.GetConnection())
            {
                var cmd = conn.CreateCommand();

                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL,
                        UserPass TEXT NOT NULL,
                        UserRole TEXT NOT NULL
                    );

                        CREATE TABLE IF NOT EXISTS Courses (
                        CouId INTEGER PRIMARY KEY AUTOINCREMENT,
                        CouCode TEXT NOT NULL,
                        CouName TEXT NOT NULL
                        
                    );

                        CREATE TABLE IF NOT EXISTS Subjects (
                        SubjectId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectCode TEXT NOT NULL,
                        SubjectName TEXT NOT NULL,
                        CourseId INTEGER NOT NULL,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
                        
                    );

                        CREATE TABLE IF NOT EXISTS Staffs (
                        StaffId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StaffName TEXT NOT NULL,
                        StaffPhone TEXT NOT NULL,
                        StaffAddress TEXT NOT NULL,
                        UserId INTEGER NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                        CREATE TABLE IF NOT EXISTS lectures (
                        LecId INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecName TEXT NOT NULL,
                        LecPhone TEXT NOT NULL,
                        LecAddress TEXT NOT NULL,
                        UserId INTEGER NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );

                        CREATE TABLE IF NOT EXISTS Students (
                        StdId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StdName TEXT NOT NULL,
                        StdPhone TEXT NOT NULL,
                        StdAddress TEXT NOT NULL,
                        UserId INTEGER,
                        FOREIGN KEY (UserId) REFERENCES Users(UserId)
                    );
                        
                        CREATE TABLE IF NOT EXISTS ClassStds (
                        ClassId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        TopicName TEXT NOT NULL,
                        StudyMode TEXT NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );

                        CREATE TABLE IF NOT EXISTS Exams (
                        ExamId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SubjectID INTEGER NOT NULL,
                        ExamName TEXT NOT NULL,
                        SemesterType TEXT NOT NULL,
                        FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
                    );

                        CREATE TABLE IF NOT EXISTS Rooms (
                        RoomId INTEGER PRIMARY KEY AUTOINCREMENT,
                        RoomName TEXT NOT NULL,
                        RoomType TEXT NOT NULL,
                        ExamID INTEGER NOT NULL,
                        ClassID INTEGER NOT NULL,
                        FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
                        FOREIGN KEY (ClassID) REFERENCES ClassStds(ClassID)
                    );

                        CREATE TABLE IF NOT EXISTS TimeTables (
                        TimeId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        RoomId INTEGER NOT NULL,
                        TimeDay TEXT NOT NULL,
                        TimeSloat TEXT NOT NULL,
                        FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
                    );

                        CREATE TABLE IF NOT EXISTS Marks (
                        StudentId INTEGER NOT NULL,
                        ExamId INTEGER NOT NULL,
                        Score INTEGER NOT NULL,
                        Grade TEXT NOT NULL,
                        PRIMARY KEY (StudentId, ExamId),
                        FOREIGN KEY (StudentId) REFERENCES Students(StudentId),
                        FOREIGN KEY (ExamId) REFERENCES Exams(ExamId)
                    );
                ";

                cmd.ExecuteNonQuery();

            }
        }
    }
}
