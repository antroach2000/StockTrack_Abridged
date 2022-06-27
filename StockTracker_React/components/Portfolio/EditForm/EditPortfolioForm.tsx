import React, { useEffect, useState } from 'react';
// @material-ui
import DialogModal from '@components/ModalDialog/Modal';
import { DialogActions } from '@material-ui/core';
// other components
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
// services
import PortfolioService from '@core/services/web-api/Portfolio';
// models
import IPortfolio from '@core/models/portfolio.model';
import IndustryGroup from '@core/models/IndustryGroup.model';
// components
import CloseButton from '@components/Buttons/Close/CloseButton';
import SaveButton from '@components/Buttons/Save/SaveButton';
import { Spinner } from 'react-bootstrap';
import SelectIndustryGroupDropDown from '@components/SelectDropDown/SelectIndustryGroup/SelectIndustryGroupDropDown';

import { useLookupList } from 'store/lookupList-context';
import { RootStateOrAny, useSelector } from 'react-redux';

type EditPortfolioFormProps = {
  portfolio: IPortfolio;
  onClose: () => void;
  onSaveSuccess: (newPortfolio: IPortfolio) => void;
  isOpen: boolean;
};

const EditPortfolioForm: React.FC<EditPortfolioFormProps> = ({
  portfolio,
  onClose,
  onSaveSuccess,
  isOpen,
}) => {
  const [openModal, setOpenModal] = useState<boolean>(isOpen);
  const [industryGroupList, setIndustryGroupList] = useState<IndustryGroup[]>();
  const appLookupList = useLookupList();
  const { token } = useSelector((state: RootStateOrAny) => state.app);

  useEffect(() => {
    //set industryGroup dropdown
    if (appLookupList.state.industryGroup)
      setIndustryGroupList([...appLookupList.state.industryGroup]);
  }, [appLookupList.state.industryGroup]);

  const initialValues = {
    portfolioName: portfolio.name,
    stockExchangeId: portfolio.stockExchangeId,
    industryGroupId: portfolio.industryGroupId,
    industryDescription: portfolio.industryDescription,
  };

  const validationSchema = Yup.object({
    portfolioName: Yup.string().required('Portfolio name is required'),
    industryGroupId: Yup.number()
      .positive()
      .required('Industry Group is required'),
  });
  const [validationError, setValidationError] = useState<boolean>(false);

  const handleUpdatePortfolio = async (formik: any) => {
    try {
      formik.setSubmitting(true);

      const portfolioService = new PortfolioService(token);
      const updatedPortfolio = {
        ...portfolio,
        name: formik.values.portfolioName,
        industryDescription: formik.values.industryDescription,
        industryGroupId: formik.values.industryGroupId,
      };

      const responsePortfolio = await portfolioService.updatePortfolio(
        updatedPortfolio,
      );

      if (responsePortfolio.httpStatusCode === 409) {
        //entity alreadys exists
        setValidationError(true);
      } else {
        onSaveSuccess(updatedPortfolio);
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
        validationSchema={validationSchema}>
        {(formik) => {
          return (
            <>
              <Form autoComplete='off'>
                <DialogModal
                  isOpen={openModal}
                  handleClose={onClose}
                  title={'Update portfolio name'}
                  height='60vh'
                  subtitle=''>
                  <label
                    htmlFor='portfolioName'
                    className='block mb-1 text-left font-semibold text-gray-700 pl-4'>
                    Portfolio Name
                  </label>

                  <div className='flex ml-2 space-y-2 flex-1 bg-transparent'>
                    <input
                      className='flex ml-2 flex-1 bg-transparent font-semibold text-base text-center rounded-semi border-2 outline-none bg-gray-100 p-1 focus:border-blue-400'
                      type='text'
                      name='portfolioName'
                      id='portfolioName'
                      placeholder='(  ie. My Super, Aus banks, Aus blue chips, USA Tech   )'
                      onChange={(e) => {
                        formik.setFieldValue('portfolioName', e.target.value);
                      }}
                      autoFocus
                      value={formik.values.portfolioName}
                      onBlur={formik.handleBlur}
                    />
                  </div>

                  {industryGroupList && (
                    <>
                      <div className='flex flex-col py-7'>
                        <label
                          htmlFor='selectIndustry'
                          className='block mb-1 text-left space-y-10 font-semibold text-gray-700 pl-4'>
                          Select Industry
                        </label>
                        <div className='flex ml-4 space-y-2 flex-1 bg-transparent'>
                          <div className='flex-grow'>
                            <SelectIndustryGroupDropDown
                              name='selectIndustry'
                              optionsData={industryGroupList}
                              value={'industryGroupId'}
                              label={'industryDescription'}
                              onChange={(selected: IndustryGroup) => {
                                formik.setFieldValue(
                                  'industryGroupId',
                                  selected.industryGroupId,
                                );
                                formik.setFieldValue(
                                  'industryDescription',
                                  selected.industryDescription,
                                );
                              }}
                              defaultValue={formik.values.industryGroupId}
                              onBlur={formik.handleBlur}
                            />
                          </div>
                        </div>
                      </div>
                    </>
                  )}

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
                          onClick={() => handleUpdatePortfolio(formik)}
                          disabled={
                            !(formik.isValid && formik.dirty) ||
                            formik.isSubmitting
                          }
                        />
                      </div>
                      {formik.isSubmitting ? (
                        <Spinner animation='border' variant='warning' />
                      ) : null}
                    </div>
                  </DialogActions>
                </DialogModal>
              </Form>
            </>
          );
        }}
      </Formik>
    </>
  );
};

export default EditPortfolioForm;
