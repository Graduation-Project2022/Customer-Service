import axios from 'axios';
import config from '../config';

class homeservices {
    async GetGeneralPlans() {
    return await axios.get(config.apiAddress + "/ReactGeneralPlans");
    }
    async GetGeneralPlan(id) {
        return await axios.get(config.apiAddress + "/ReactGeneralPlans/" + id);
    }
    async GetPlansQuantity(id) {
        return await axios.get(config.apiAddress + "/ReactPlansQuantities/" + id);
    }
    async GetPlansServicesPrice(id) {
        return await axios.get(config.apiAddress + "/PlansServicesPrices/" + id);
    }
    async GetMobileNumber(id) {
        return await axios.get(config.apiAddress + "/ReactMobileNumbers/" + id);
    }
    async PutMobileNumber(id, mobileNumber) {
        return await axios.get(config.apiAddress + "/ReactMobileNumbers/" + id, mobileNumber);
    }
    async GetPlan(id) {
        return await axios.get(config.apiAddress + "/ReactPlans/" + id);
    }
    async GetInvoice(id) {
        return await axios.get(config.apiAddress + "/ReactInvoices/" + id);
    }
    async GetCurrentQuantityBalance(id) {
        return await axios.get(config.apiAddress + "/ReactCurrentQuantityBalances/" + id);
    }
}
const service = new homeservices();
export default service;