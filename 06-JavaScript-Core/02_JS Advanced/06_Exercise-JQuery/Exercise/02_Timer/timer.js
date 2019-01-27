function timer() {
    let interval;
    let totalSeconds = 0;

    function startTimer() {
        let $hours = $('#hours');
        let $minutes = $('#minutes');
        let $seconds = $('#seconds');
        
        let hours = "00";
        let minutes = "00";
        let seconds = "00";

        if(!interval) {
            interval = setInterval(function() {
                totalSeconds++;
                hours = `0${Math.trunc((totalSeconds / 60 / 60) % 24)}`.slice(-2);
                minutes = `0${Math.trunc((totalSeconds / 60) % 60)}`.slice(-2);
                seconds = `0${totalSeconds % 60}`.slice(-2);
    
                $hours.text(hours);
                $minutes.text(minutes);
                $seconds.text(seconds);
            }, 1000);
        }
    }
    
    function stopTimer() {
        if(interval) {
            clearInterval(interval);
            interval = null;
        }
    }

    $('#start-timer').on("click", startTimer);
    $('#stop-timer').on("click", stopTimer);
}