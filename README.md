# HrTask
Task of Head Result and Task for Remain <br/>
[![Build Status](https://github.com/DirectSQL/HrTask/workflows/.NET%20Core/badge.svg?branch=master)](https://github.com/DirectSQL/HrTask/actions)<br/>
[![CodeFactor](https://www.codefactor.io/repository/github/DirectSQL/HrTask/badge/master)](https://www.codefactor.io/repository/github/DirectSQL/HrTask/overview/master)<br/>

# Test Run
`````
public void TestRun()
{
    var task = new HrTask<int, int[]>(() => {
        return (
            1,
            () => new int[] { 2, 3 }
        );
    });

    task.Start();

    var result = task.Result;
    Assert.AreEqual(result.headResult, 1);

    var remainResult = result.remainTask.Result;
    CollectionAssert.AreEqual(remainResult, new int[] { 2, 3 });
}
`````

# Test Async
`````
public async Task TestAsync()
{
    var task = new HrTask<int, int[]>(() => {
        return (
            1,
            () => new int[] { 2, 3 }
        );
    });

    task.Start();

    var result = await task;
    Assert.AreEqual(result.headResult, 1);

    var remainResult = await result.remainTask;
    CollectionAssert.AreEqual(remainResult, new int[] { 2, 3 });
}
`````
