//function that runs on generate content button press
function generateContent(){

    //unhide the generatedEmail HTML section
    var generatedEmail = document.getElementById("generatedEmail");
    generatedEmail.style.display = "block";
   
    //initialize variables with user inputs
    var mainMessage = document.getElementById("mainMessage").value;
    var outageStart = new Date(document.getElementById("outageStart").value);
    var outageFinish = new Date(document.getElementById("outageFinish").value);
    var affApps = document.getElementById("affApps").value;
    var locations = getLocationCheckboxes();
    var userAction = document.getElementById("userAction").value;
    var note = document.getElementById("note").value;

    //initialize the Time Zones for conversions along with the Time Zone display namespaces
    let tzConversion = ['Atlantic/Bermuda', 'America/Virgin', 'America/Cayman', 'Asia/Hong_Kong', 'Europe/London', 'Asia/Singapore'];
    let tzDisplay = ['Bermuda', 'British Virgin Islands', 'Cayman Islands', 'Hong Kong', 'London', 'Singapore'];

    //populate the email content (all but conversion table and footer)
    var content =   "<img src='heading.jpg'>" +

                    "<p id='message'><strong>" + mainMessage + "\n\n</strong></p>" +

                    "\n<hr align='left'>\n" +

                    "<table><tr><td class='colOne'>Outage Start:</td><td class='colTwo'>" + formatTime(outageStart) +

                    "</td></tr><tr><td class='colOne'>Outage Finish:</td><td class='colTwo'>" + formatTime(outageFinish) +

                    "</td></tr><tr><td class='colOne'>Affected Applications:</td><td class='colTwo'>" + affApps +

                    "</td></tr><tr><td class='colOne'>Affected Locations:</td><td class='colTwo'>" + locations +

                    "</td></tr><tr><td class='colOne'>User Actions Required:</td><td class='colTwo'>" + userAction +

                    "</td></tr><tr><td class='colOne'>NOTE:</td><td class='colTwo' id='noteMessage'><mark><u>" + note +

                    "</u></mark></td></tr><td colspan=2><p>We will notify you when the work is complete and systems are available</p></td></td></tr></table>"

               

    //add formatted email message to HTML window
    var mainContent = document.getElementById("mainContent");
    mainContent.innerHTML += content;
               
    //loop through and convert to all the time zones, and add the to the HTML table
    let count=0;
    tzConversion.forEach((timeZone) =>{
        let convStartTime = convertTimezone(outageStart, timeZone);
        let convEndTime = convertTimezone(outageFinish, timeZone);
        addTableRow(tzDisplay[count], convStartTime, convEndTime);
        count++;
    });

}

//function for verifying checkboxes
function getLocationCheckboxes()
{
    const checkboxes = document.getElementsByName("locations");
    const selectedCheckboxes = [];
    let checkboxString = ""; 

    checkboxes.forEach((cb) => 
    {
        if (cb.checked){selectedCheckboxes.push(cb.value);}
    });

    let locNum = selectedCheckboxes.length-1;

    if(selectedCheckboxes.length == 1){return selectedCheckboxes;}

    else
    {
        for(let i = 0; i < locNum; i++)
        {
            checkboxString += selectedCheckboxes[i] + ", ";
        }     

        checkboxString += selectedCheckboxes[locNum];
        return checkboxString;
    }
}

//fomart date/time for Outage Start/Finish (in main part of message)
function formatTime(time)
{
    let options = 
    {
        weekday: 'long',
        month: 'long',
        day: 'numeric',
        year: 'numeric',
        hour12: false,
        hour: 'numeric',
        minute: 'numeric'
    };

    let timeString = time.toLocaleString('en-US', options);
    let finalDate = timeString + ' hrs EST';
    console.log(finalDate);

    return finalDate;
}

//convert and format time converstions for outage table
function convertTimezone(time, timeZone){

    let options = 
    {
        timeZone: timeZone,
        month: 'long',
        day: 'numeric',
        hour12: false,
        hour: 'numeric',
        minute: 'numeric'
    };

    let timeString = time.toLocaleString('en-US', options);
    let finalDate = timeString.split(' at ')[0] + ', ' + timeString.split(' at ')[1] + ' hrs';

    return finalDate;
}

//add table row for converstion table
function addTableRow(timeZone, convStartTime, convEndTime)
{
    let tableBody = document.getElementById("timeZoneBody");
    let newRow = tableBody.insertRow(-1);
    let cell1 = newRow.insertCell(0);
    let cell2 = newRow.insertCell(1);
    let cell3 = newRow.insertCell(2);
    cell1.textContent = timeZone;
    cell2.textContent = convStartTime;
    cell3.textContent = convEndTime;
}