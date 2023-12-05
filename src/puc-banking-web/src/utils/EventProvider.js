const eventCollection = [];

export function subscribe(event, action) {

    var eventData = eventCollection
        .find((element) => {
            if (element.key === event) {
                return element;
            }
        });

    if (!eventData) {
        eventCollection.push({ key: event, listeners: [action] })
    } else {
        eventData.listeners.push(action);
    }
}

export function publish(event, params) {

    var eventData = eventCollection
        .find((element) => {
            if (element.key === event) {
                return element;
            }
        });

    if (eventData) {
        eventData.listeners.map((action) => {
            action(params);
        });
    }
}

const EventProvider = { subscribe, publish };

export default EventProvider;
