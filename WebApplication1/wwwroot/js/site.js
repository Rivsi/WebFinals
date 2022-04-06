$(".btnShow").mousedown(function () {
    $(".pwd").attr("type", "text");
});
$(".btnShow").on("mouseleave", function () {
    $(".pwd").attr("type", "password");
});



const myFunction = () => {
    const columns = [
        { name: 'Student Name', index: 1, isFilter: true },
        { name: 'Last Name', index: 2, isFilter: true }
    ]
    const filterColumns = columns.filter(c => c.isFilter).map(c => c.index)
    const trs = document.querySelectorAll(`#myTable tr:not(.header)`)
    const filter = document.querySelector('#myInput').value
    const regex = new RegExp(escape(filter), 'i')
    const isFoundInTds = td => regex.test(td.innerHTML)
    const isFound = childrenArr => childrenArr.some(isFoundInTds)
    const setTrStyleDisplay = ({ style, children }) => {
        style.display = isFound([
            ...filterColumns.map(c => children[c]) // <-- filter Columns
        ]) ? '' : 'none'
    }

    trs.forEach(setTrStyleDisplay)
}