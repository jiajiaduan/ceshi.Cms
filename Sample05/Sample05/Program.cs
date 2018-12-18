using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            //test_insert();
            test_mult_insert();
            Console.ReadLine();
        }

        /// <summary>
        /// 测试插入单条数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",

            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=1;Initial Catalog=sq_menhu;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试一次批量插入两条数据
        /// </summary>
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>() {
               new Content
            {
                title = "批量插入标题1",
                content = "批量插入内容1",

            },
               new Content
            {
                title = "批量插入标题2",
                content = "批量插入内容2",

            },
        };

            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=1;Initial Catalog=sq_menhu;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                (title, [content], status, add_time, modify_time)
VALUES   (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }
        public class Content
        {
            /// <summary>
            /// 主键
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// 标题
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 内容
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 状态 1正常 0删除
            /// </summary>
            public int status { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime add_time { get; set; } = DateTime.Now;
            /// <summary>
            /// 修改时间
            /// </summary>
            public DateTime? modify_time { get; set; }
        }
        public class Comment
        {
            /// <summary>
            /// 主键
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 文章id
            /// </summary>
            public int content_id { get; set; }
            /// <summary>
            /// 评论内容
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 添加时间
            /// </summary>
            public DateTime add_time { get; set; } = DateTime.Now;
        }
    }
}
