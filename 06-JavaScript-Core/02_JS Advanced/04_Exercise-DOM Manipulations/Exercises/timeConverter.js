function attachEventsListeners() {
    let daysBtn = document.getElementById("daysBtn");
    daysBtn.addEventListener("click", calcByDays);
    let hoursBtn = document.getElementById("hoursBtn");
    hoursBtn.addEventListener("click", calcByHours);
    let minutesBtn = document.getElementById("minutesBtn");
    minutesBtn.addEventListener("click", calcByMinutes);
    let secondsBtn = document.getElementById("secondsBtn");
    secondsBtn.addEventListener("click", calcBySeconds);

    let days = document.getElementById("days");
    let hours = document.getElementById("hours");
    let minutes = document.getElementById("minutes");
    let seconds = document.getElementById("seconds");

    function calcByDays() {
        let daysAsNumber = +days.value;
        hours.value = daysAsNumber * 24;
        minutes.value = daysAsNumber * 24 * 60;
        seconds.value = daysAsNumber * 24 * 60 * 60;
    }

    function calcByHours() {
        let hoursAsNumber = +hours.value;
        days.value = hoursAsNumber / 24;
        minutes.value = hoursAsNumber * 60;
        seconds.value = hoursAsNumber * 60 * 60;
    }

    function calcByMinutes() {
        let minutesAsNumber = +minutes.value;
        days.value = (minutesAsNumber / 60) / 24;
        hours.value = minutesAsNumber / 60;
        seconds.value = minutesAsNumber * 60;
    }

    function calcBySeconds() {
        let secondsAsNumber = +seconds.value;
        days.value = ((secondsAsNumber / 60) / 60) / 24;
        hours.value = (secondsAsNumber / 60) / 60;
        minutes.value = secondsAsNumber / 60;
    }
}