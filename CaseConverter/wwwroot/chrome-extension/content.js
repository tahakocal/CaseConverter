document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('getHtmlButton').addEventListener('click', function () {
        chrome.tabs.query({active: true, currentWindow: true}, function (tabs) {
            chrome.scripting.executeScript({
                target: {tabId: tabs[0].id},
                function: getPageHTML
            });
        });


    });
});

function getPageHTML() {
    const html = document.documentElement.outerHTML;

    fetch(" http://localhost:5169/Home/post-data", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({html: html}),
    })
        .then((response) => {
            if (!response.ok) {
                throw new Error("API'ye HTML gönderilirken bir hata oluştu.");
            }
            return response.blob();
        })
        .then((blob) => {
            const url = window.URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = 'taigaFramerStealer.zip';
            document.body.appendChild(a);
            a.click();
        })
        .catch((error) => {
            console.error(error.message);
        });
}