$(document).ready(function () {
    const apiUrl = 'http://localhost:5224/api/Subjects';
    let existingSubjects = [];

    function loadSubjects() {
        $.ajax({
            url: `${apiUrl}/viewallsubject`,
            type: 'GET',
            success: function (data) {
                existingSubjects = data; // Store existing subjects for client-side validation
                const tableBody = $('#subjects-table tbody');
                tableBody.empty();
                data.forEach(subject => {
                    tableBody.append(`
                        <tr data-id="${subject.subjectId}">
                            <td>${subject.subjectId}</td>
                            <td>${subject.subjectName}</td>
                            <td>
                                <button class="btn btn-warning btn-sm edit-btn">Edit</button>
                            </td>
                        </tr>
                    `);
                });
            },
            error: function () {
                alert('Failed to load subjects.');
            }
        });
    }

    loadSubjects();

    // Add or Edit Subject
    $('#subject-form').on('submit', function (e) {
        e.preventDefault();
        const subjectId = $('#subjectId').val();
        const subjectName = $('#subjectName').val().trim();

        // Client-side validation: Check if the subject name already exists
        if (existingSubjects.some(subject => subject.subjectName.toLowerCase() === subjectName.toLowerCase() && subject.subjectId != subjectId)) {
            alert('A subject with this name already exists.');
            return;
        }

        const url = subjectId ? `${apiUrl}/editsubject?id=${subjectId}` : `${apiUrl}/addsubject`;
        const type = subjectId ? 'PUT' : 'POST';

        $.ajax({
            url: url,
            type: type,
            contentType: 'application/json',
            data: JSON.stringify(subjectName),
            success: function () {
                $('#subject-form')[0].reset();
                $('#subjectId').val('');
                $('#form-title').text('Add Subject');
                loadSubjects();
            },
            error: function (xhr) {
                let errorMessage = 'Failed to save subject.';

                if (xhr.status === 409) { // Conflict status code for duplicate subject
                    errorMessage = 'A subject with this name already exists.';
                }

                alert(errorMessage);
            }
        });
    });

    // Edit Button Click
    $('#subjects-table').on('click', '.edit-btn', function () {
        const row = $(this).closest('tr');
        const subjectId = row.data('id');
        const subjectName = row.find('td:eq(1)').text();

        $('#subjectId').val(subjectId);
        $('#subjectName').val(subjectName);
        $('#form-title').text('Edit Subject');
    });
});
