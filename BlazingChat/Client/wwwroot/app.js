
const storage = window.localStorage;

window.getFromStorage = (key) => storage.getItem(key);

window.setToStorage = (key, value) => storage.setItem(key, value);

window.removeFromStorage = (key) => storage.removeItem(key);

window.scrollToLastMessage = () => {
    var lastMessageLi = document.querySelector('#messages-ul > li:last-child');
    if (lastMessageLi) {
        lastMessageLi.scrollIntoView({
            behavior: 'smooth'
        });
    }
}