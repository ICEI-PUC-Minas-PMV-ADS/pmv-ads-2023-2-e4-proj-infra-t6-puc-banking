export function splitCardNumber(number) {

    number = number.replace(/\s/g, '');

    if (!/^\d{16}$/.test(number)) {
        console.error('O número do cartão deve ter exatamente 16 dígitos.');
        return;
    }

    let numberFormat = number.replace(/(\d{4})/g, '$1 ');

    numberFormat = numberFormat.trim();

    return numberFormat;
}

export function getDatetime(dateTime) {
    const datetime = new Date(Date.parse(dateTime));

    const month = datetime.getMonth() + 1;
    const year = datetime.getFullYear();

    const formatDate = `${month.toString().padStart(2, '0')}/${year.toString().slice(-2)}`;

    console.log(dateTime);

    return formatDate;
}
