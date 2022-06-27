import React, { useEffect, useState } from 'react';
// @material-ui
import { DialogActions } from '@material-ui/core';
// other components
import { Formik, ErrorMessage } from 'formik';
import * as Yup from 'yup';
// services
import PortfolioService from '@core/services/web-api/Portfolio';
// models
import IPortfolio from '@core/models/portfolio.model';
import IIndustryGroup from '@core/models/IndustryGroup.model.';
import IStockExchangeModel from '@core/models/StockExchange.model';
// components
import SelectCountryDropDown from '@components/SelectDropDown/SelectCountry/SelectCountryDropDown';
import SaveButton from '@components/Buttons/Save/SaveButton';
import CloseButton from '@components/Buttons/Close/CloseButton';
import SelectIndustryGroupDropDown from '@components/SelectDropDown/SelectIndustryGroup/SelectIndustryGroupDropDown';
import DialogModal from '@components/ModalDialog/Modal';
import { useLookupList } from 'store/lookupList-context';
import { RootStateOrAny, useSelector } from 'react-redux';

type AddPortfolioProps = {
  onClose: () => void;
  onSaveSuccess: (newPortfolio: IPortfolio) => void;
  isOpen: boolean;
};

const AddPortfolio: React.FC<AddPortfolioProps> = ({
  onClose,
  onSaveSuccess,
  isOpen,
}) => {
  const initialValues = {
    portfolioName: '',
    stockExchangeId: 0,
    industryGroupId: 0,
  };
  const [openModal, setOpenModal] = useState<boolean>(isOpen);
  const [validationError, setValidationError] = useState<boolean>(false);
  const [industryGroupList, setIndustryGroupList] = useState<IIndustryGroup[]>();
  const [stockExchangeList, setStockExchangeList] =
    useState<IStockExchangeModel[]>();
  const appLookupList = useLookupList();
  const { token } = useSelector((state: RootStateOrAny) => state.app);

  useEffect(() => {
    //set industryGroup for dropdown
    if (appLookupList.state.industryGroup)
      setIndustryGroupList([...appLookupList.state.industryGroup]);
  }, [appLookupList.state.industryGroup]);

  useEffect(() => {
    //set stockExchangeList for dropdown
    if (appLookupList.state.stockExchangeList)
      setStockExchangeList([...appLookupList.state.stockExchangeList]);
  }, [appLookupList.state.stockExchangeList]);

  const formValidationSchema = Yup.object({
    portfolioName: Yup.string().required('Portfolio name is required'),
    stockExchangeId: Yup.number()
      .positive()
      .required('Stock Exchange is required'),
    industryGroupId: Yup.number()
      .positive()
      .required('Industry Group is required'),
  });

  const handleAddPortfolio = async (formik: any) => {
    try {
      formik.setSubmitting(true);
      setValidationError(false);

      const portfolioService = new PortfolioService(token);

      const newPortfolio: IPortfolio = {
        name: formik.values.portfolioName,
        stockExchangeId: formik.values.stockExchangeId,
        industryGroupId: formik.values.industryGroupId,
      };

      //add new portfolio
      const responseNewPortfolio = await portfolioService.addPortfolio(
        newPortfolio,
      );

      if (!responseNewPortfolio.errorMessage) {
        onSaveSuccess(responseNewPortfolio.data);
      } else {
        //entity alreadys exists
        setValidationError(true);
      }
    } catch (error) {
      debugger;
      console.log(`error `, error);
    }

    formik.setSubmitting(false);
  };

  return (
    <>
      <Formik
        initialValues={initialValues}
        onSubmit={(values, actions) => {}}
        validationSchema={formValidationSchema}>
        {(formik) => {
          return (
            <>
              <form autoComplete='off'>
                <DialogModal
                  isOpen={openModal}
                  handleClose={onClose}
                  title={'Add new portfolio'}
                  height='60vh'
                  subtitle=''>
                  {stockExchangeList && (
                    <>
                      <label
                        htmlFor='selectStockExchange'
                        className='block mb-1 text-left font-semibold text-gray-700 pl-2'>
                        Select Stock Exchange
                      </label>
                      <div className='flex ml-2 space-y-2 flex-1 bg-transparent'>
                        <div className='flex-grow'>
                          <SelectCountryDropDown
                            name='selectCountry'
                            optionsData={stockExchangeList}
                            value={'stockExchangeId'}
                            label={'exchangeName'}
                            onChange={(selected: IStockExchangeModel) => {
                              formik.setFieldValue(
                                'stockExchangeId',
                                selected.stockExchangeId,
                              );
                            }}
                            defaultValue={formik.values.stockExchangeId}
                            onBlur={formik.handleBlur}
                          />
                        </div>
                      </div>

                      <div className='block mb-1 text-center font-semibold text-red-600'>
                        <ErrorMessage name='stockExchangeId' />
                      </div>
                    </>
                  )}

                  {industryGroupList && (
                    <>
                      <label
                        htmlFor='selectIndustry'
                        className='block mb-1 text-left font-semibold text-gray-700 pl-2'>
                        Select Industry
                      </label>
                      <div className='flex ml-2  space-y-2  flex-1 bg-transparent'>
                        <div className='flex-grow'>
                          <SelectIndustryGroupDropDown
                            name='selectIndustry'
                            optionsData={industryGroupList}
                            value={'industryGroupId'}
                            label={'industryDescription'}
                            onChange={(selected: IIndustryGroup) => {
                              formik.setFieldValue(
                                'industryGroupId',
                                selected.industryGroupId,
                              );
                            }}
                            defaultValue={formik.values.industryGroupId}
                            onBlur={formik.handleBlur}
                          />
                        </div>
                      </div>

                      <div className='block mb-1 text-center font-semibold text-red-600'>
                        <ErrorMessage name='industryGroupId' />
                      </div>
                    </>
                  )}
                  <label
                    htmlFor='portfolioName'
                    className='block mb-1 text-left font-semibold text-gray-700 pl-2'>
                    Portfolio Name
                  </label>
                  <div className='flex bg-transparent'>
                    <input
                      className='flex ml-2 flex-1 bg-transparent font-semibold text-base text-center rounded-semi border-2 outline-none bg-gray-100 p-1 focus:border-blue-400'
                      type='text'
                      name='portfolioName'
                      id='portfolioName'
                      placeholder='(  ie. My Super, Aus banks, Aus miners, USA Tech   )'
                      onChange={(e) => {
                        formik.setFieldValue('portfolioName', e.target.value);
                      }}
                      onBlur={formik.handleBlur}
                    />
                  </div>
                  <div>
                    {validationError && (
                      <div className='block mb-1 text-center font-semibold text-red-600'>
                        Portfolio {formik.values.portfolioName} already exists
                      </div>
                    )}
                  </div>
                  <div className='flex flex-col p-24'></div>
                  <DialogActions>
                    <div className='flex flex-1'>
                      <div className='flex w-1/2 items-start pl-4'>
                        <CloseButton
                          disabled={formik.isSubmitting}
                          text='Close'
                          onClick={() => onClose()}
                        />
                      </div>
                      <div className='flex w-1/2 justify-end  pr-2'>
                        <SaveButton
                          onClick={() => handleAddPortfolio(formik)}
                          disabled={
                            !(formik.isValid && formik.dirty) ||
                            formik.isSubmitting
                          }
                        />
                      </div>
                    </div>
                  </DialogActions>
                </DialogModal>
              </form>
            </>
          );
        }}
      </Formik>
    </>
  );
};

export default AddPortfolio;
