$(document).ready(function () {

    const firstApiCall = $.ajax({
        url: 'http://localhost:5224/api/Dashboard/student_analysis',
        method: 'GET'
    });

    const secondApiCall = $.ajax({
        url: 'http://localhost:5224/api/Dashboard/subject_analysis',
        method: 'GET'
    });

    $.when(firstApiCall, secondApiCall).done(function (firstApiResponse, secondApiResponse) {
        const leaderboardData = firstApiResponse[0];
        const dashboardData = secondApiResponse[0];

        const topStudentsContainer = $("#top-students-container");
        const leaderboardTable = $("#leaderboard-table tbody");
        const dashboardGrid = $("#dashboard-grid");
        leaderboardTable.empty();
        topStudentsContainer.empty();
        dashboardGrid.empty();

        leaderboardData.sort((a, b) => b.AverageGrade - a.AverageGrade);

        const styles = ['second-place', 'first-place', 'third-place'];

        leaderboardData.slice(0, 3).forEach((student, index) => {
            const studentCard = `
                        <div class="student-card ${styles[index]}">
                            <div class="student-avatar"></div>
                            <div class="student-info">
                                <h4>${student.studentName}</h4>
                                <p style="text-align: center">${student.averageGrade.toFixed(2)}</p>
                            </div>
                        </div>`;
            topStudentsContainer.append(studentCard);
        });

        leaderboardData.slice(3).forEach((student, index) => {
            const row = `<tr>
                                <td>${index + 4}</td>
                                <td>${student.studentName}</td>
                                <td>${student.averageGrade.toFixed(2)}</td>
                             </tr>`;
            leaderboardTable.append(row);
        });

        dashboardData.forEach((subject, index) => {
            let gradientColors;
            if (subject.averageGrade < 50) {
                gradientColors = { start: 'rgba(255, 0, 0, 1)', end: 'rgba(255, 0, 0, 1)' };
            } else if (subject.averageGrade < 70) {
                gradientColors = { start: 'rgba(255, 255, 0, 1)', end: 'rgba(255, 255, 0, 1)' };
            } else {
                gradientColors = { start: 'rgba(0, 255, 0, 1)', end: 'rgba(0, 255, 0, 1)' };
            }

            const gradientId = `gradient-${index}`;

            const row = `<div class="grid-item">
                            <div class="box-content">
                                <div class="circular-progress">
                                    <svg class="progress-ring" width="100" height="100">
                                        <circle class="progress-ring__background" stroke="#d3d3d3" stroke-width="10" fill="transparent" r="45" cx="50" cy="50" />
                                        <circle id="progress-circle-${index}" class="progress-ring__circle" stroke="url(#${gradientId})" stroke-width="10" fill="transparent" r="45" cx="50" cy="50"/>
                                        <defs>
                                            <linearGradient id="${gradientId}" x1="1" y1="0" x2="0" y2="1">
                                                <stop offset="0%" stop-color="${gradientColors.start}" />
                                                <stop offset="100%" stop-color="${gradientColors.end}" />
                                            </linearGradient>
                                        </defs>
                                    </svg>
                                    <span id="progress-value-${index}" class="progress-value">${subject.averageGrade}/100</span>
                                </div>
                                <h4>${subject.subjectName}</h4>
                                <hr style="border: solid 1px lightgray"/>
                                <a href="#" onclick="exportAndDownload(${subject.subjectId})">Export Full Report</a>
                            </div>
                         </div>`;
            dashboardGrid.append(row);
            setProgress(subject.averageGrade, `#progress-circle-${index}`, `#progress-value-${index}`);
        });

    }).fail(function (xhr, status, error) {
        console.error("Error with API calls: ", error);
    });
});


function setProgress(percent, circleSelector, valueSelector) {
    const circle = document.querySelector(circleSelector);
    const radius = circle.r.baseVal.value;
    const circumference = 2 * Math.PI * radius;

    circle.style.strokeDasharray = `${circumference}`;
    circle.style.strokeDashoffset = `${circumference - (percent / 100) * circumference}`;

    document.querySelector(valueSelector).textContent = `${percent}/100`;
}

async function exportAndDownload(subjectId) {
    document.getElementById('loading-overlay').style.display = 'flex';

    try {
        const response = await fetch(`http://localhost:5224/api/Dashboard/export_subject_analysis?subjectId=${subjectId}`);

        if (!response.ok) {
            const errorMessage = await response.text();
            alert(`Failed: ${errorMessage}`);
            return;
        }

        const blob = await response.blob();
        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = `SubjectAnalysis_${subjectId}.xlsx`;
        document.body.appendChild(link);
        link.click();
        link.remove();
        alert('An error occurred.');
    } catch (error) {
        console.error('Error downloading the file:', error);
        alert('An error occurred.');
    } finally {
        document.getElementById('loading-overlay').style.display = 'none';
    }
}
