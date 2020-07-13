var cart = {
    init: function () {
        cart.reEvents();
    },
    reEvents: function () {
        $('#btn_continue').off('click').on('click', function () {
            window.location.href= "/san-pham";
        });
        $('#btn_order').off('click').on('click', function () {
            window.location.href = "/dat-hang";
        });

        $('#btn_clearall').off('click').on('click', function () {
            
            $.ajax({

                url: '/Cart/ClearallProduct',
               
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({

                data: {id:$(this).data('id')},
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

    }
}
cart.init();