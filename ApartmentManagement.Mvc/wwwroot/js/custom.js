function ShowConfirm(title = null, content = null, yesFunction = null, noFunction = null, bgDismiss = true, yesText = "Evet", noText = "HAYIR") {
    $.confirm({
        animation: 'top',
        closeAnimation: 'bottom',
        title: title,
        content: content,
        backgroundDismiss: bgDismiss,
        boxWidth: 'fit-content',
        boxHeight: 'auto',
        useBootstrap: false,
        backgroundDismissAnimation: 'glow',
        animateFromElement: false,
        buttons: {
            Yes: {
                text: yesText,
                keys: ['enter'],
                btnClass: "btn-yes",
                action: function () {
                    yesFunction();
                }
            },
            No: {
                text: noText,
                btnClass: "btn-no",
                keys: ['esc'],
                action: function () {
                    noFunction();
                }
            },
        }
    });
}

const resultType = {
    success: 1,
    error: 2,
    warning: 3,
    information: 4
}

class Result {
    constructor(result) {
        this.resultStatus = result.resultType;
        this.messages = result.messages;
        this.data = result.data;
    }
    get getMessages() {
        for (let message of this.messages) {
            var messageColorCode = 'green';
            var title = '';
            switch (this.resultStatus) {
                case resultType.information:
                    messageColorCode = 'blue';
                    title = 'Bilgi';
                    break;
                case resultType.warning:
                    messageColorCode = 'yellow';
                    title = 'Uyarı';
                    break;
                case resultType.error:
                    messageColorCode = 'red';
                    title = 'Hata';
                    break;
            }

            iziToast.show({
                theme: 'dark',
                title: title,
                message: message,
                position: 'center',
                progressBarColor: 'rgb(155, 255, 184)',
                overlay: true,
                overlayClose: false
            });
        }
    }
    getMessagesFunction(successFunction, errorFunction) {
        this.getMessages;
        if (this.resultStatus == resultType.success) {
            successFunction();
        } else {
            errorFunction();
        }
    }
}

function getFormData(formId) {
    var formData = new FormData(document.getElementById(formId));

    return Object.fromEntries(
        Array.from(formData.keys()).map(key => [
            key.replace("Data.", ""), formData.getAll(key).length > 1 ?
                formData.getAll(key) : formData.get(key)
        ]));
}