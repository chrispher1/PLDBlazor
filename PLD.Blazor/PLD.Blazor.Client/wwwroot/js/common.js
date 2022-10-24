window.DisplayModal = (name) => {
    var myModal = new bootstrap.Modal(document.getElementById(name), {
        keyboard: false
    })
    myModal.show();
    
}