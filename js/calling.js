// https://developer.mozilla.org/en-US/docs/web/api/document/cookie
// y asi se enviaria el control de CSFR desde el cliente xhr
const xsrfToken = document.cookie
    .split("; ")
    .find(row => row.startsWith("XSRF-TOKEN="))
    .split("=")[1];

const response = await fetch("/weatherforecast", {
    method: "POST",
    headers: { "X-XSRF-TOKEN": xsrfToken }
});

if (response.ok) {
    alert( await response.text());
} else {
    alert( `Request Failed: ${response.status}`)
}
