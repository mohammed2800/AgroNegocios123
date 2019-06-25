toastr.options = {
	"closeButton": true,
	"debug": false,
	"positionClass": "toast-top-left",
	"onclick": null,
	"showDuration": "1000",
	"hideDuration": "1000",
	"timeOut": "5000",
	"extendedTimeOut": "1000",
	"showEasing": "swing",
	"hideEasing": "linear",
	"showMethod": "fadeIn",
	"hideMethod": "fadeOut"
};

var toastrSuccess = function (msg) {
	toastr.success(msg);
}

var toastrInfo = function (msg) {
	toastr.info(msg);
}

var toastrWarning = function (msg) {
	toastr.warning(msg);
}

var toastrError = function (msg) {
	toastr.error(msg);
}