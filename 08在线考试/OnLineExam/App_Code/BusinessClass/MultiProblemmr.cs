﻿using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using OnLineExam.DataBaseClass;
using OnLineExam.HelperClass;


namespace OnLineExam.BusinessClass
{
    //多选题类
    public class MultiProblemmr
    {
        #region 私有成员
        private int _ID;                                               //题目编号
        private int _CourseID;                                         //所属科目        
        private string _Title;                                         //题目      
        private string _AnswerA;                                       //答案A
        private string _AnswerB;                                       //答案B
        private string _AnswerC;                                       //答案C
        private string _AnswerD;                                       //答案D
        private string _Answer;                                        //答案

        #endregion 私有成员

        #region 属性

        public int ID
        {
            set
            {
                this._ID = value;
            }
            get
            {
                return this._ID;
            }
        }
        public int CourseID
        {
            set
            {
                this._CourseID = value;
            }
            get
            {
                return this._CourseID;
            }
        }
        public string Title
        {
            set
            {
                this._Title = value;
            }
            get
            {
                return this._Title;
            }
        }
        public string AnswerA
        {
            set
            {
                this._AnswerA = value;
            }
            get
            {
                return this._AnswerA;
            }
        }
        public string AnswerB
        {
            set
            {
                this._AnswerB = value;
            }
            get
            {
                return this._AnswerB;
            }
        }
        public string AnswerC
        {
            set
            {
                this._AnswerC = value;
            }
            get
            {
                return this._AnswerC;
            }
        }
        public string AnswerD
        {
            set
            {
                this._AnswerD = value;
            }
            get
            {
                return this._AnswerD;
            }
        }
        public string Answer
        {
            set
            {
                this._Answer = value;
            }
            get
            {
                return this._Answer;
            }
        }
        
        #endregion 属性

        #region 方法

        //根据题目ID 初始化题目
        //输入：
        //      TID - 题目编号；
        //输出：
        //      如果考试题目存在：返回True；
        //      如果考试题目不在：返回False；
        public bool LoadData(int TID)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();
            string strsql = "SELECT * FROM MultiProblemmr where ID=@ID";
            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, TID);                  //用户编号            

            DataSet ds = DB.GetStrDataSetSql(strsql, Params);
            ds.CaseSensitive = false;
            DataRow DR;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DR = ds.Tables[0].Rows[0];
                this._CourseID = GetSafeData.ValidateDataRow_N(DR, "CourseID");                   //科目编号                
                this._Title = GetSafeData.ValidateDataRow_S(DR, "Title");                         //题目
                this._AnswerA = GetSafeData.ValidateDataRow_S(DR, "AnswerA");                     //答案A
                this._AnswerB = GetSafeData.ValidateDataRow_S(DR, "AnswerB");                     //答案B
                this._AnswerC = GetSafeData.ValidateDataRow_S(DR, "AnswerC");                     //答案C
                this._AnswerD = GetSafeData.ValidateDataRow_S(DR, "AnswerD");                     //答案D
                this._Answer = GetSafeData.ValidateDataRow_S(DR, "Answer");                       //答案
                return true;
            }
            else
            {
                return false;
            }
        }


        //向MultiProblemmr表中添加题目信息(
        //输出：
        //      如果插入成功：返回True；
        //      如果插入失败：返回False；
        public bool InsertByStr()
        {
            SqlParameter[] Params = new SqlParameter[7];

            DataBase DB = new DataBase();
            string strsql = "INSERT INTO MultiProblemmr (CourseID,Title,AnswerA,AnswerB,AnswerC,AnswerD,Answer) VALUES (@CourseID,@Title,@AnswerA,@AnswerB,@AnswerC,@AnswerD,@Answer)";
            Params[0] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, CourseID);                 //科目编号
            Params[1] = DB.MakeInParam("@Title", SqlDbType.VarChar, 1000, Title);                //题目            
            Params[2] = DB.MakeInParam("@AnswerA", SqlDbType.VarChar, 500, AnswerA);            //答案A
            Params[3] = DB.MakeInParam("@AnswerB", SqlDbType.VarChar, 500, AnswerB);            //答案B
            Params[4] = DB.MakeInParam("@AnswerC", SqlDbType.VarChar, 500, AnswerC);            //答案C
            Params[5] = DB.MakeInParam("@AnswerD", SqlDbType.VarChar, 500, AnswerD);            //答案D
            Params[6] = DB.MakeInParam("@Answer", SqlDbType.VarChar, 50, Answer);                //答案

            int Count = -1;
            Count = DB.ProcStr(strsql, Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //更新多选题的信息
        public bool UpdateByStr(int TID)
        {
            SqlParameter[] Params = new SqlParameter[8];

            DataBase DB = new DataBase();
            string strsql = "UPDATE MultiProblemmr SET CourseID= @CourseID,Title= @Title,AnswerA= @AnswerA,AnswerB= @AnswerB,AnswerC= @AnswerC,AnswerD= @AnswerD,Answer= @Answer WHERE (ID = @ID)";
            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, TID);                           //题目编号
            Params[1] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, CourseID);                //科目编号
            Params[2] = DB.MakeInParam("@Title", SqlDbType.VarChar, 1000, Title);               //题目            
            Params[3] = DB.MakeInParam("@AnswerA", SqlDbType.VarChar, 500, AnswerA);            //答案A
            Params[4] = DB.MakeInParam("@AnswerB", SqlDbType.VarChar, 500, AnswerB);            //答案B
            Params[5] = DB.MakeInParam("@AnswerC", SqlDbType.VarChar, 500, AnswerC);            //答案C
            Params[6] = DB.MakeInParam("@AnswerD", SqlDbType.VarChar, 500, AnswerD);            //答案D
            Params[7] = DB.MakeInParam("@Answer", SqlDbType.VarChar, 50, Answer);                //答案

            int Count = -1;
            Count = DB.ProcStr(strsql, Params);
            if (Count > 0)
                return true;
            else return false;
        }


        //删除题目
        //输入：
        //      TID - 题目编号；
        //输出：
        //      如果删除成功：返回True；
        //      如果删除失败：返回False；
        public bool DeleteByStr(int TID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();
            string strsql = "DELETE FROM MultiProblemmr WHERE (ID= @ID)";
            Params[0] = DB.MakeInParam("@ID", SqlDbType.Int, 4, TID);               //题目编号          

            int Count = -1;
            Count = DB.ProcStr(strsql, Params);
            if (Count > 0)
                return true;
            else return false;
        }

        //查询单选题
        //课程编号
        public DataSet QueryMultiProblem(int TCourseID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();
            string strsql = "SELECT MultiProblemmr.ID, MultiProblemmr.Title FROM MultiProblemmr where CourseID=@CourseID";
            Params[0] = DB.MakeInParam("@CourseID", SqlDbType.Int, 4, TCourseID);               //题目编号           
            return DB.GetStrDataSetSql(strsql, Params);
        }  

        #endregion 方法
    }
}