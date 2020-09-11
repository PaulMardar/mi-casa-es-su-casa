export class Request {
    phone: string;
    auto: string;
    stamp: string;
    status: number;

    constructor(phone, auto, stamp, status) {
        this.phone = phone;
        this.auto = auto;
        this.stamp = stamp;
        this.status = status;
    }
}
