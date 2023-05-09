const notyf = new Notyf({
    duration: 4000,
    position: {
        x: 'right',
        y: 'top',
    },
    ripple: false,
    dismissible: true,
    types: [
        {
            type: 'warning',
            background: '#f7cf19',
            icon: {
                className: 'material-icons',
                tagName: 'i',
                text: 'warning',
                color: 'white'
            }
        },
        {
            type: 'info',
            background: '#2D91A3',
            icon: {
                className: 'material-icons',
                tagName: 'i',
                text: 'info',
                color: 'white'
            }
        }
    ]
});
