window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}

function downloadFile(fileName, fileContent) {
    var link = document.createElement('a');
    link.download = fileName;
    link.href = "data:application/octet-stream;base64," + fileContent;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function initializeCalendar(kalenders) {
    // document.addEventListener('DOMContentLoaded', function () {
    //     var calendarEl = document.getElementById(elementId);
    //     var calendar = new FullCalendar.Calendar(calendarEl, {
    //         initialView: 'dayGridMonth',
    //         events: events
    //     });
    //     calendar.render();
    // });
    const Calendar = tui.Calendar;
    const calendar = new Calendar('#calendar', {
        defaultView: 'week',
        template: {
            time(event) {
                const { start, end, title } = event;

                return `<span style="color: white;">${formatTime(start)}~${formatTime(end)} ${title}</span>`;
            },
            allday(event) {
                return `<span style="color: gray;">${event.title}</span>`;
            },
        },
        calendars: kalenders,
    })
}

function InitJSCalendar(elementId, events) {
    var calendarEl = document.getElementById(elementId);
    var calendar = new FullCalendar.Calendar(calendarEl, {
        schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
        initialView: 'timeGridWeek',
        timeZone: 'UTC',
        locale: 'id',
        firstDay: 1,
        allDaySlot: false,
        nowIndicator: true,
        slotMinTime: "05:00:00",
        slotMaxTime: "23:00:00",
        headerToolbar: {
            left: 'prev,next',
            center: 'title',
            right: 'timeGridWeek,timeGridDay' // user can switch between the two
        },
        events: events
    });
    calendar.render();
}

function handleEventMount(info) {
    var tooltip = new Tooltip(info.el, {
        title: info.event.extendedProps.description,
        placement: 'top',
        trigger: 'hover',
        container: 'body'
    });
}

function InitResourceTimeline(elementId, events, resources) {
    var calendarEl = document.getElementById(elementId);
    var calendar = new FullCalendar.Calendar(calendarEl, {
        schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
        initialView: 'resourceTimelineDay',
        aspectRatio: 1.5,
        locale: 'id',
        firstDay: 1,
        allDaySlot: false,
        nowIndicator: true,
        slotMinTime: "05:00:00",
        slotMaxTime: "23:00:00",
        headerToolbar: {
            left: 'prev,next',
            center: 'title',
            right: 'resourceTimelineDay,resourceTimelineWeek,resourceTimelineMonth'
        },
        resourceAreaHeaderContent: 'Ruang',
        resourceGroupField: 'gedung',
        events: events,
        resources: resources,
        eventDidMount: handleEventMount
    });
    calendar.render();
}