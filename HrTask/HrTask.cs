﻿using System;
using System.Threading.Tasks;

namespace HrTask
{
    ///<summary>
    /// Task results to a heading one and remained tasks. 
    ///</summary>
    /// <typeparam name="H">Type of heading result</typeparam>
    /// <typeparam name="R">Type of remaining result</typeparam>
    public class HrTask<H,R> : Task<(H headResult, Task<R> remainTask)> 
    {
        public delegate R RemainFunc();
        public delegate (H headResult, Task<R> remainTask) HRTaskFunc();
        public delegate (H headResult, RemainFunc remainTaskFunc) HRFunc();

        ///<summary>
        /// Construct a HrTask 
        ///</summary>
        ///<param name="func">Function to be processed in HrTask</param>
        public HrTask(HRTaskFunc func) 
            : base(() => {
                    var result = func();
                    result.remainTask.Start();
                    return result;
                }
            ) 
        {
        }

        ///<summary>
        /// Construct a HrTask 
        ///</summary>
        ///<param name="func">Function to be processed in HrTask</param>
        public HrTask(HRFunc func)
            : this(() => {
                var r = func();
                return (r.headResult, new Task<R>(() => r.remainTaskFunc()));
            })
        {
        }
    }
}
