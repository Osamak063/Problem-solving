// how to make your own promise.
function theLoveLetterMystery(s) {
    const arr = [...s];
    let i=0, j=arr.length - 1;
    let num = 0;
    while(i<j){
        if(arr[i] != arr[j])
        {
            num += Math.abs(arr[i].charCodeAt() - arr[j].charCodeAt());
        }
        ++i;
        --j;
    }
    return num;
}
