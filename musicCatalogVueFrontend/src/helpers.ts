export function getTimeLocaleString(timestamp: number) {
    const dateObject = new Date(timestamp);
    return dateObject.toLocaleString();
}