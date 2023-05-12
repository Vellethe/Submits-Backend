export default function fakeFetch(urlString, options) {
    const url = new URL(urlString);

    if (url.hostname === 'https://localhost:5000/Explore' && url.pathname === '/api/') {
        if (url.searchParams.get('q') === 'arms') {
            return {
                total: 4,
                totalHits: 4,
                hits: [
                    {
                        webformatURL: '/fake-images/biggestarms.jpg'
                    },
                    {
                        webformatURL: '/fake-images/armday.jpg'
                    },
                    {
                        webformatURL: '/fake-images/bicepsforever.jpg'
                    },
                    {
                        webformatURL: '/fake-images/tricepspower.jpg'
                    }
                ]
            }
        }
        else if (url.searchParams.get('q') === 'panda') {
            return {
                total: 2,
                totalHits: 2,
                hits: [
                    {
                        webformatURL: '/fake-images/panda.jpg'
                    },
                    {
                        webformatURL: '/fake-images/redpanda.jpg'
                    }
                ]
            }
        }
        else {
            return {
                total: 0,
                totalHits: 0,
                hits: []
            }
        }
    }
    else {
        throw new Error('This URL has not been implemented in the fake API: ' + urlString);
    }
}